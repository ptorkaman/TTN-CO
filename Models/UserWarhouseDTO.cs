
namespace DTO
{
    public  class UserWarhouseDTO : BaseClassDTO<long> 
    {
        public UserWarhouseDTO()
        {
            Warehouse = new WarehouseDTO();
            User = new UserDTO();
        }
        public int UserId { get; set; }
        public int WarehouseId { get; set; }

        public virtual WarehouseDTO Warehouse { get; set; }
        public virtual UserDTO User { get; set; }

    }
}
