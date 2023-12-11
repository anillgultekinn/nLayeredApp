using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
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
        //Product product = new Product(); //product oluşturuldu
        //product.Id = Guid.NewGuid();
        //product.ProductName = createdProductRequest.ProductName;
        //product.UnitPrice = createdProductRequest.UnitPrice;
        //product.QuantityPerUnit = createdProductRequest.QuantityPerUnit;
        //product.UnitsInStock = createdProductRequest.UnitsInStock;
        ////veritabanına atıldı

        //Product createdProduct = await _productDal.AddAsync(product); //veritabanında oluşan

        //CreatedProductResponse createdProductResponse = new CreatedProductResponse(); //yanıt nesnesi oluşturuldu
        //createdProductResponse.Id = createdProduct.Id;
        //createdProductResponse.ProductName = createdProduct.ProductName;
        //createdProductResponse.UnitPrice = createdProduct.UnitPrice;
        //createdProductResponse.QuantityPerUnit = createdProduct.QuantityPerUnit;
        //createdProductResponse.UnitsInStock = createdProduct.UnitsInStock;
        ////veritabanında oluşturulanları response atıldı ve dönüldü
        //return createdProductResponse;


        var product = _mapper.Map<Product>(createProductRequest);
        var addedProduct = await _productDal.AddAsync(product);
        var responseProduct = _mapper.Map<CreatedProductResponse>(addedProduct);
        return responseProduct;


    }



    //Poor Code
    public async Task<IPaginate<GetListProductResponse>> GetListAsync()
    {
        var productList = await _productDal.GetListAsync();
        var mappedList = _mapper.Map<Paginate<GetListProductResponse>>(productList);
        return mappedList;

        //var productList = await _productDal.GetListAsync();

        //List<GetListProductResponse> listResponseItems = new List<GetListProductResponse>();

        //foreach (var product in productList.Items)
        //{
        //    listResponseItems.Add(new GetListProductResponse
        //    {
        //        Id = product.Id,
        //        ProductName = product.ProductName,
        //        QuantityPerUnit = product.QuantityPerUnit,
        //        UnitPrice = product.UnitPrice,
        //        UnitsInStock = product.UnitsInStock
        //    });
        //}

        //Paginate<GetListProductResponse> listResponse = new Paginate<GetListProductResponse>();
        //listResponse.Items = listResponseItems;
        //listResponse.Count = productList.Count;
        //listResponse.Index = productList.Index;
        //listResponse.Size = productList.Size;
        //listResponse.From = productList.From;
        //listResponse.Pages = productList.Pages;

        //return listResponse;

    }
}
