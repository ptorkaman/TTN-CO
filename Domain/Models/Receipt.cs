using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Receipt", Schema = "TTN")]
    public class Receipt : BaseClass<long> 
    { 
        public int BijakNo { get; set; }
        public string ReferenceNo { get; set; }
        public int senderId { get; set; }
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

        public decimal FreightAmt { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal InsuranceAmt { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal CityAmt { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal PassingAmt { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal DerricAmt { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal DownloadAmt { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal InstitutionAmt { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal PerfixAmt { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal TotalAmt { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal TipAmt { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal Startlatitude { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal Startlongitude { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal Destinationlatitude { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal Destinationlongtude { get; set; }
        public int ForceType { get; set; }

    }
}
