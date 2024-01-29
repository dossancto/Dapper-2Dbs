using Microsoft.AspNetCore.Mvc;
using Two.Application.Features.Users.Entities;

namespace Two.UI.Controllers.Users;

public partial class UserController
{
    /// <summary>
    /// All Users
    /// </summary>
    /// <remarks>Delete a user using Id</remarks>
    /// <response code="200">User deleted</response>
    /// <response code="500">Oops! Can't delete this user now</response>
    [ProducesResponseType(typeof(User), 201)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<ActionResult<User>> SelectAll()
    {
        var users = await _select.All();

        return Ok(users);
    }
}

