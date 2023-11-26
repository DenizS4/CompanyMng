using CompanyMng.Application.Business.Companies.Commands;
using CompanyMng.Application.Business.Companies.Queries;
using CompanyMng.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompanyMng.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<Companies>> GetCompany()
    {
        return await _mediator.Send(new GetCompanyQuery());
    }
    [HttpGet]
    [Route("GetTotalCompany")]
    public async Task<int> GetTotalCompany()
    {
        return await _mediator.Send(new GetTotalCompaniesQuery());
    }
    [HttpGet]
    [Route("GetLatestCompany")]
    public async Task<List<Companies>> GetLatestCompany()
    {
        return await _mediator.Send(new GetLatestThreeCompaniesQuery());
    }
    
    [HttpPost]
    [Route("AddCompany")]
    public async Task<IActionResult> AddCompany(AddCompanyCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPost]
    [Route("UpdateCompany")]
    public async Task<IActionResult> UpdateCompany(UpdateCompanyCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpDelete]
    [Route("DeleteCompany")]
    public async Task<IActionResult> DeleteCompany(DeleteCompanyCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}