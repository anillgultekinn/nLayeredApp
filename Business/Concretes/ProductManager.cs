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

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public async Task<CreatedProductResponse> Add(CreatedProductRequest createdProductRequest)
    {
        Product product = new Product();
        product.Id = Guid.NewGuid();
        product.ProductName = createdProductRequest.ProductName;
        product.UnitPrice = createdProductRequest.UnitPrice;
        product.QuantityPerUnit = createdProductRequest.QuantityPerUnit;
        product.UnitsInStock = createdProductRequest.UnitsInStock;

        Product createdProduct = await _productDal.AddAsync(product);

        CreatedProductResponse createdProductResponse = new CreatedProductResponse();
        createdProductResponse.Id = createdProduct.Id;
        createdProductResponse.ProductName = createdProduct.ProductName;
        createdProductResponse.UnitPrice = createdProduct.UnitPrice;
        createdProductResponse.QuantityPerUnit = createdProduct.QuantityPerUnit;
        createdProductResponse.UnitsInStock = createdProduct.UnitsInStock;

        return createdProductResponse;
    }

    public Task<IPaginate<Product>> GetListAsync()
    {

    }
}
