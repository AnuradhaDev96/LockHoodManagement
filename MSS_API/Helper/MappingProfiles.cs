using AutoMapper;
using MSS_API.Dto;
using MSS_API.Models.Inventories;

namespace MSS_API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Inventory, InventoryDto>();
            CreateMap<InventoryDto, Inventory>();
            CreateMap<InventoryItems, InventoryItemsDto>();
            CreateMap<InventoryItemsDto, InventoryItems>();
        }
    }
}
