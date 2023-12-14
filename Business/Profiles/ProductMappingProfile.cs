using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        //Product entity içinde categoryname yok Category var


        CreateMap<Product, GetListProductResponse>().
            ForMember(destinationMember: p => p.CategoryName,  //p de ki CategoryName 'e 
                memberOptions: opt => opt.MapFrom(p => p.Category.Name))  //p nin Category sinin Name inden maple
            .ReverseMap();

        CreateMap<Product, CreatedProductResponse>().ReverseMap();

        CreateMap<IPaginate<Product>, Paginate<GetListProductResponse>>();

        CreateMap<Product, CreateProductRequest>().ReverseMap();

        //alan isimlerine bakarak mapleme yapılır
        //ürünlerimiz var ama category ile ilgili bilgi gelmiyor 
        //

    }
}
