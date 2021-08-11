
using System.ComponentModel;

namespace DTO
{
    public  class SenderReciverDTO : BaseClassDTO<int> 
    {
        public int CityId { get; set; }
        public string CompanyName { get; set; }

        public string CompanyCode { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
        public ClassType Type { get; set; }
    }

    public enum ClassType
    {
        [Description("Sender")]
        Sender = 1
        ,
        [Description("Reciever")]
        Reciever = 2
    }
}