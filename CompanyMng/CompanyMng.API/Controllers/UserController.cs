using CompanyMng.Application.Authentication.Users.Commands;
using CompanyMng.Application.Authentication.Users.Queries;
using CompanyMng.Domain.Entities;
using CompanyMng.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompanyMng.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<Users>> GetUsers()
    {
        return await _mediator.Send(new GetUserQuery());
    }
    
    [HttpGet]
    [Route("GetUserByRole")]
    public async Task<Roles> GetUserRole(string username)
    {
        return await _mediator.Send(new GetUserRoleQuery(username));
    }
    [HttpGet]
    [Route("GetTotalUsers")]
    public async Task<int> GetTotalUser()
    {
        return await _mediator.Send(new GetTotalUsersQuery());
    }
    
    [HttpGet]
    [Route("GetLatestUser")]
    public async Task<List<Users>> GetLatestUser()
    {
        return await _mediator.Send(new GetLatestThreeUsersQuery());
    }
    
    [HttpPost]
    [Route("AddUser")]
    public async Task<IActionResult> AddUser(AddUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPost]
    [Route("UpdateUser")]
    public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpDelete]
    [Route("DeleteUser")]
    public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPost]
    [Route("AuthUser")]
    public async Task<bool> AuthUser(string username, string password)
    {
        return await _mediator.Send(new AuthUserQuery(username, password));
    }
}