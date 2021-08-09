using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("BijakBin", Schema = "TTN")]

    public class BijakBin : BaseClass<int> 
    { 
        public long BijakId { get; set; }
        public int BinId { get; set; }
        

    }
}
