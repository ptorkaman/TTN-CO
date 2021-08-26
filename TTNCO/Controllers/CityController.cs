using Common.Extensions;
using Common.Utilities;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using TTNCO.Result;
using System.Data.OleDb;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;

namespace TTNCO.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    //[AllowAnonymous]
    //[Route("api/[controller]")]
    //[Authorize]
    public class CityController : BaseController
    {
        #region Fields
        private readonly ICityService _cityService;
        private readonly IProvinceService _provinceService;
        #endregion

        #region CTOR

        public CityController(ICityService cityService, IProvinceService provinceService)
        {
            _cityService = cityService;
             _provinceService= provinceService;
        }
        #endregion

        #region City Actions
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
    }
}

