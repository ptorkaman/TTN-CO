namespace DTO
{
    public partial class MenuDTO:BaseClassDTO<long>
    {
        public string Name { get; set; }
       // public long PermissionId { get; set; }
        //public virtual PermissionDTO Permission { get; set; }
        public long? ParentId { get; set; }
    }
}
