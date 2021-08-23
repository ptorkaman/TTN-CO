using AutoMapper;
using DTO;
using Domain;
using System.Collections.Generic;

namespace Services.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            AllowNullDestinationValues = true;
            //Source -> Destination
            //

            CreateMap<VehicleManager, VehicleManagerDTO>();
            CreateMap<VehicleType, VehicleTypeDTO>();
            CreateMap<StuffManager, StuffManagerDTO>();
            CreateMap<PackageType, PackageTypeDTO>();

            CreateMap<ReceiptStatus, ReceiptStatusDTO>();
            CreateMap<UserMenu, UserMenuDTO>();

            CreateMap<City, CityDTO>();
            CreateMap<Country, CountryDTO>();
            CreateMap<Province, ProvinceDTO>();
            CreateMap<Parish, ParishDTO>();

            CreateMap<ReceiptStatus, ReceiptStatusDTO>();
            CreateMap<Region, RegionDTO>();
            CreateMap<Person, PersonDTO>();
            CreateMap<Receipt, ReceiptDTO>();
            CreateMap<ReceiptBin, ReceiptBinDTO>();
            CreateMap<ReceiptDetail, ReceiptDetailDTO>();
            CreateMap<Bin, BinDTO>();
            CreateMap<Menu, MenuDTO>();
            CreateMap<Permission, PermissionDTO>();
            CreateMap<SenderReciver, SenderReciverDTO>();
            CreateMap<Region, RegionDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<RolePermission, RolePermissionDTO>();
            CreateMap<Sender, SenderDTO>();
            CreateMap<SenderWarehouse, SenderWarehouseDTO>();
            CreateMap<TransportationDetail, TransportationDtlDTO>();
            CreateMap<Unit, UnitDTO>();
            CreateMap<UserRole, UserRoleDTO>();
            CreateMap<UserType, UserTypeDTO>();
            CreateMap<UserWarhouse, UserWarhouseDTO>();
            CreateMap<Warehouse, WarehouseDTO>();
            CreateMap<WehicleType, WehicleTypeDTO>();
            CreateMap<MenuPermission, MenuPermissionDTO>();
            CreateMap<GroupUser, GroupUserDTO>();
            //CreateMap<List<UserMenu>, List<UserMenuDTO>>();
            
        }
    }
}