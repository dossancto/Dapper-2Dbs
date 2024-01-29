using Two.Application.Features.Users.Entities;
namespace Two.Application.Features.Users.Data;

public interface IUserRepository
{
    Task<User> Save(User user);
    Task<User> Update(User user);

    Task<User?> GetByEmail(string email);
    Task<User?> GetById(string id);

    Task<IEnumerable<User>> All();

    Task DeleteById(string id);
}

