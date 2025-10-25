using AutoMapper;
using FintechCore.Application.Dtos.Setups;
using FintechCore.Domain.Entities.Setups;

namespace FintechCore.Application.MappingProfiles;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        CreateMap<Branch, BranchDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<Field, FieldDto>();
        CreateMap<Form, FormDto>();
        CreateMap<Lov, LovDto>();
    }
}