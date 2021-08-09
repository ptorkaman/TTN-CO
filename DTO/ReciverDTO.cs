
namespace DTO
{
    public  class ReciverDTO : BaseClassDTO<int> 
    {
        public int CityId { get; set; }
        public string CompanyName { get; set; }

        public string CompanyCode { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

    }
}
