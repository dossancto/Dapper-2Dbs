using Microsoft.AspNetCore.Mvc;
using Two.Application.Features.Users.UseCases;

namespace Two.UI.Controllers.Users;

[ApiController]
[Route("[controller]")]
public partial class UserController : ControllerBase
{
    private readonly RegisterUserUseCase _register;
    private readonly LoginUserUseCase _login;
    private readonly SelectUserUseCase _select;
    private readonly DeleteUserUseCase _delete;

    public UserController(RegisterUserUseCase register, LoginUserUseCase login, DeleteUserUseCase delete, SelectUserUseCase select)
    {
        _register = register;
        _login = login;
        _delete = delete;
        _select = select;
    }
}
