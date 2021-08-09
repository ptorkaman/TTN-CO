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

            CreateMap<City, CityDTO>();
            CreateMap<Country, CountryDTO>();
            CreateMap<Province, ProvinceDTO>();
            CreateMap<Parish, ParishDTO>();

            CreateMap<BijakStatus, BijakStatusDTO>();
            CreateMap<Region, RegionDTO>();
            CreateMap<Person, PersonDTO>();
            CreateMap<Receipt, BijakDTO>();
            CreateMap<BijakBin, BijakBinDTO>();
            CreateMap<ReceiptDetail, BijakDtlDTO>();
            CreateMap<Bin, BinDTO>();
            CreateMap<Menu, MenuDTO>();
            CreateMap<Permission, PermissionDTO>();
            CreateMap<Reciver, ReciverDTO>();
            CreateMap<Region, RegionDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<RolePermission, RolePermissionDTO>();
            CreateMap<Sender, SenderDTO>();
            CreateMap<SenderWarehouse, SenderWarehouseDTO>();
            CreateMap<TransportationDtl, TransportationDtlDTO>();
            CreateMap<Unit, UnitDTO>();
            CreateMap<UserRole, UserRoleDTO>();
            CreateMap<UserType, UserTypeDTO>();
            CreateMap<UserWarhouse, UserWarhouseDTO>();
            CreateMap<Warehouse, WarehouseDTO>();
            CreateMap<WehicleType, WehicleTypeDTO>();
            CreateMap<MenuPermission, MenuPermissionDTO>();
            CreateMap<GroupUser, GroupUserDTO>();
            CreateMap<List<UserMenu>, List<UserMenuDTO>>();
            
        }
    }
}