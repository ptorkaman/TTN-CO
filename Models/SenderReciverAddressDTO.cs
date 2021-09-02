
using System.ComponentModel;

namespace DTO
{
    public  class SenderReciverAddressDTO : BaseClassDTO<int> 
    {
        public SenderReciverDTO SenderReciver { get; set; }
        public int SenderReciverId { get; set; }
        public string Address { get; set; }
    }
}