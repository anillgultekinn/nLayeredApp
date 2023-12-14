using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Entities.Concretes;

namespace Business.Profiles;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CreatedCategoryResponse>().ReverseMap();
        CreateMap<Category, CreateCategoryRequest>().ReverseMap();

        //alan isimlerine bakarak mapleme yapılır

    }
}
