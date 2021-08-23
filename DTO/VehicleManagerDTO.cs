namespace DTO
{
    public class VehicleManagerDTO : BaseClassDTO<int>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string NationalCode { get; set; }
        public string VehicleNumber { get; set; }
        public int VehicleTypeId { get; set; }
    }
}
