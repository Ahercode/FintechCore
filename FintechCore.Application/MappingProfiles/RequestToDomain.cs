using AutoMapper;
using FintechCore.Application.Dtos.Setups;
using FintechCore.Domain.Entities.Setups;

namespace FintechCore.Application.MappingProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<CreateBranchDto, Branch>();
        CreateMap<UpdateBranchDto, Branch>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
        CreateMap<CreateFieldDto, Field>();
        CreateMap<UpdateFieldDto, Field>();
        CreateMap<CreateFormDto, Form>();
        CreateMap<UpdateFormDto, Form>();
        CreateMap<CreateLovDto, Lov>();
        CreateMap<UpdateLovDto, Lov>();
    }
}