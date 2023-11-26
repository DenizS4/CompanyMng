using CompanyMng.Application.Business.Products.Commands;
using CompanyMng.Application.Business.Products.Queries;
using CompanyMng.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompanyMng.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<Products>> GetProduct()
    {
        return await _mediator.Send(new GetProductQuery());
    }
    
    [HttpGet]
    [Route("GetTotalProduct")]
    public async Task<int> GetTotalProduct()
    {
        return await _mediator.Send(new GetTotalProductsQuery());
    }
    [HttpGet]
    [Route("GetLatestProduct")]
    public async Task<List<Products>> GetLatestProduct()
    {
        return await _mediator.Send(new GetLatestThreeProductsQuery());
    }
    [HttpGet]
    [Route("GetTopProduct")]
    public async Task<List<Products>> GetTopProduct()
    {
        return await _mediator.Send(new GetTopThreeProductsQuery());
    }
    [HttpGet]
    [Route("GetProductsByCompany")]
    public async Task<Dictionary<string,int>> GetProductsByCompany()
    {
        return await _mediator.Send(new GetProductsByCompanyQuery());
    }
    
    [HttpPost]
    [Route("AddProduct")]
    public async Task<IActionResult> AddProduct(AddProductCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPost]
    [Route("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpDelete]
    [Route("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(DeleteProductCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    
}