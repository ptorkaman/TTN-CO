using System;
using Common.Extensions;
using Common.Utilities;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using albim.Result;
using DAL.Models;
using TTN.Controllers.v1;
using TTN;

namespace TTNCO.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Authorize]
    //[Route("api/[controller]")]
    //[Authorize]
    public class CityController : BaseController
    {
        #region Fields
        private readonly ICityService _cityService;
        private readonly IProvinceService _provinceService;
        private TTNContext _context;

        #endregion

        #region CTOR

        public CityController(ICityService cityService, IProvinceService provinceService,TTNContext context)
        {
            _cityService = cityService;
             _provinceService= provinceService;
             _context = context;

        }
        #endregion

        #region City Actions
        [HttpPost("FindAll")]
        public DtoBase FindAll(SpecificationOfDataList<CityDTO> filter)
        {
            //var session = HttpContext.Session;
            //var userId = 0;
            //string ip = null;
            DtoBase result = new DtoBase();
            try
            {
                filter.FilterSpecifications.Add(new FilterSpecification<CityDTO>()
                {
                    FilterValue = "te",
                    PropertyName = "Name",
                    FilterOperation = FilterOperations.NotEqual
                });
                var obj = _cityService.FindAll(filter.PageSize, filter.PageIndex, filter.GetCriteria());
                result.Results = obj;
                result.DtoIsValid = true;
                result.Status = "200";
                //LoggerProxy.Log(LoggerProxy.LogLevels.Info, typeof(Type), " Success " + Request.RequestUri + " || userId:" + userId + " UserIP:" + ip, null);
                return result;
            }
            catch (Exception e)
            {
                result.DtoIsValid = false;
                result.Status = "500";
                result.MessageError.Add(e.ToString());
                //LoggerProxy.Log(LoggerProxy.LogLevels.Error, typeof(Type), " Faild( " + e + "   )" + this.Request.RequestUri + " || userId:" + userId + " UserIP:" + ip, null);
                return result;
            }
        }

        [HttpPost()]
        public async Task<ApiResult<CityDTO>> Create(CityDTO modelDto, CancellationToken cancellationToken)
        {
            modelDto.CreatedBy = HttpContext.User.Identity.GetUserId<int>();

            var result = await _cityService.Create(modelDto, cancellationToken);
            return result;
        }

        [HttpDelete("{Id}")]
        public async Task<ApiResult<string>> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _cityService.DeleteAsync(Id, cancellationToken);
            return result.ToString();
        }

        [HttpPut("{Id}")]
        public async Task<ApiResult<CityDTO>> Update(int Id, CityDTO modelDto, CancellationToken cancellationToken)
        {
            var result = await _cityService.UpdateAsync(Id, modelDto, cancellationToken);
            return result;
        }

     

        [HttpGet("Get")]
        public async Task<ApiResult<List<CityDTO>>> Get(CancellationToken cancellationToken)
        {
            var result = await _cityService.GetAsync(cancellationToken);
            foreach (var item in result)
            {
                item.ProvinceTitle = _provinceService.GetById(item.ProvinceId).Result.ProvinceName;
            }
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResult<PagedResult<City>>> GetAll(int? page, [FromQuery] int? pageSize, [FromQuery] string orderBy, CancellationToken cancellationToken)
        {
            var result = await _cityService.GetAllAsync(page, pageSize, orderBy, cancellationToken);
            return result;
        }

        //[HttpGet()]
        //public async Task<bool> GetExcell(CancellationToken cancellationToken)
        //{
        //   var constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", "D:\\Project\\city.xlsx");
        //   string strConnection = "Data Source=.\\SQLEXPRESS;AttachDbFilename='C:\\Users\\Hemant\\documents\\visual studio 2010\\Projects\\CRMdata\\CRMdata\\App_Data\\Database1.mdf';Integrated Security=True;User Instance=True";

        //   string excelConnString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", filePath);
        //   //Create Connection to Excel work book 
        //   using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
        //   {
        //       //Create OleDbCommand to fetch data from Excel 
        //       using (OleDbCommand cmd = new OleDbCommand("Select [ID],[Name],[Designation] from [Sheet1$]", excelConnection))
        //       {
        //           excelConnection.Open();
        //           using (OleDbDataReader dReader = cmd.ExecuteReader())
        //           {
        //               using (SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection))
        //               {
        //                   //Give your Destination table name 
        //                   sqlBulk.DestinationTableName = "Excel_table";
        //                   sqlBulk.WriteToServer(dReader);
        //               }
        //           }
        //       }
        //   }

        //    return true;
        //}
        #endregion
//        [HttpGet("ImportExcel")]
//        public object GetDataExcelFile()
//        {
//            OleDbConnection conn = new OleDbConnection();
//            string fullPathToExcel = "D:\\city.xlsx"; //ie C:\Temp\YourExcel.xls
//            string fileExtension = Path.GetExtension(fullPathToExcel);
//            if (fileExtension == ".xls")
//                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullPathToExcel + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
//            if (fileExtension == ".xlsx")
//                conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fullPathToExcel + ";Extended Properties=Excel 12.0;";
//            string connString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fullPathToExcel + ";" + "Extended Properties='Excel 8.0;HDR=YES;'");

//            #region Province
//            //DataTable dt = GetDataTable("SELECT * from [province$]", connString);
//            //IList<Province> dataList = new List<Province>();
//            //foreach (DataRow dr in dt.Rows)
//            //{
//            //    Province data = new Province();

//            //    data.ProvinceName = dr[5].ToString() ;
//            //    data.Id =Convert.ToInt32( dr[6]);
//            //    data.CreatedBy = 1;
//            //    data.CreatedDate=DateTime.Now;
//            //    data.IsActive = true;
//            //    CancellationToken cancellationToken = new CancellationToken();
//            //    _context.Provinces.Add(data);
//            //    _context.SaveChanges();
//            //    //_provinceService.Create(data,cancellationToken);
//            //    //Save(data);
//            //    dataList.Add(data);
//            //    //Do what you need to do with your data here
//            //}d


//            #endregion

//            #region City
//            DataTable dt = GetDataTable("SELECT * from [city$]", connString);
//            IList<City> dataList = new List<City>();
//            foreach (DataRow dr in dt.Rows)
//            {
//                City data = new City();

//                data.Name = dr[6].ToString();
//                data.Id = Convert.ToInt32(dr[4]);
//                data.CreatedBy = 1;
//                data.CreatedDate = DateTime.Now;
//                data.IsActive = true;
//                data.Latitude = Convert.ToDecimal(dr[7]);
//                data.Longitude = Convert.ToDecimal(dr[8]);
//                data.ProvinceId =Convert.ToInt32(dr[5]) ;
//                CancellationToken cancellationToken = new CancellationToken();
//                _context.Cities.Add(data);
//                _context.SaveChanges();
//                //_provinceService.Create(data,cancellationToken);
//                //Save(data);
//                dataList.Add(data);
//                //Do what you need to do with your data here
//            }

//#endregion
//            return null;
//        }
//        [NonAction]
//        private DataTable GetDataTable(string sql, string connectionString)
//        {
//            DataTable dt = new DataTable();
//            using (OleDbConnection conn = new OleDbConnection(connectionString))
//            {
//                conn.Open();
//                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
//                {
//                    using (OleDbDataReader rdr = cmd.ExecuteReader())
//                    {
//                        dt.Columns.Add("Code");
//                        dt.Columns.Add("Name");
//                        dt.Columns.Add("Family");
//                        dt.Columns.Add("Count");
//                        dt.Load(rdr);

//                    }
//                }
//            }
//            return dt;
//        }
    }
}

