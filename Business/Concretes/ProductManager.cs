using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class ProductManager : IProductService
{
    IProductDal _productDal;
    IMapper _mapper;

    public ProductManager(IProductDal productDal, IMapper mapper)
    {
        _productDal = productDal;
        _mapper = mapper;
    }
    public async Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest)
    {
        Product product = _mapper.Map<Product>(createProductRequest); //Gelen createProductRequest i product çevir
        Product createdProduct = await _productDal.AddAsync(product); //product veritabanına ekle
        CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(createdProduct); 
        return createdProductResponse;

    }

    public async Task<IPaginate<GetListProductResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _productDal.GetListAsync(
            include: p => p.Include(p => p.Category),  //join attık
            index: pageRequest.PageIndex,              // index = 1    size = 3 dersek 4,5,6.kayıtları verir 
            size: pageRequest.PageSize              
            );
        var result = _mapper.Map<Paginate<GetListProductResponse>>(data);
        return result;
    }
}
