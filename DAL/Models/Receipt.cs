using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Receipts")]
    public class Receipt : BaseClass<long> 
    {
        public Receipt()
        {
            ReceiptDetail = new List<ReceiptDetail>();
        }
        public int ReceiptNo { get; set; }
        public string ReferenceNo { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public int? StartwarhouseId { get; set; }
        public int? DestinationWarhouseId { get; set; }
        public bool? Istransport1 { get; set; }
        public bool? Istransport2 { get; set; }
        public int StartingCity { get; set; }
        public int DestinationCity { get; set; }
        public int? NeedIncurance { get; set; }
        public int Remark { get; set; }
        public int StatusId { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal FreightAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal InsuranceAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal CityAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal PassingAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal DerricAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal DownloadAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal InstitutionAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal PerfixAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal TotalAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal TipAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal Startlatitude { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal Startlongitude { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal Destinationlatitude { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal Destinationlongtude { get; set; }
        public int ForceType { get; set; }
        public IList<ReceiptDetail> ReceiptDetail { get; set; }
        public virtual Bin Bin { get; set; }
        public int BinId { get; set; }
        public virtual ReceiptStatus ReceiptStatus { get; set; }
        public int ReceiptStatusId { get; set; }
        public bool IsPeyment { get; set; }
    }
}
