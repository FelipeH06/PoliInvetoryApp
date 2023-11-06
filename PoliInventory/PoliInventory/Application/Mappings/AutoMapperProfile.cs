using AutoMapper;
using PoliInventory.Application.DTOs;
using PoliInventory.Domain.Entities;

namespace PoliInventory.Application.Mappings
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryEntity, CategoryDto>().ForMember(x=>x.Id, y=>y.MapFrom(c=>c.Id));
            CreateMap<CategoryDto, CategoryEntity>().ForMember(x => x.Id, y => y.MapFrom(c => c.Id));
        }
    }
}
