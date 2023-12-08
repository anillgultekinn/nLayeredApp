using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatedProductRequest createdProductRequest)
        {
            var result = await _productService.Add(createdProductRequest);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _productService.GetListAsync();
            return Ok(result);
        }
    }
}
