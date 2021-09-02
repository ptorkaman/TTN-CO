
namespace DTO
{
    public  class WehicleTypeDTO : BaseClassDTO<int> 
    {
        public string Name { get; set; }
        public string Dimension { get; set; }
        public string FactoryId { get; set; }
        public string DownloadType { get; set; }
        public int MinimumCapacity { get; set; }
        public int MaximumCapacity { get; set; }


    }
}
