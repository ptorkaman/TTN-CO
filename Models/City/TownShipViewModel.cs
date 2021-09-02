namespace Models.City
{
    public class TownShipViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public long ProvinceId { get; set; }
    }
}
