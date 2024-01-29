using Two.Application.Features.Users.Data;
using Two.Infra.Database.Dapper.Utils;
using Two.Application.Features.Users.Entities;

using NanoidDotNet;
using Two.Infra.Database.Dapper.Contexts;
using Dapper;

namespace Two.Infra.Database.Dapper.Repositories;

public class DapperUserRepository : IUserRepository
{
    private readonly GeneralDbContext _context;

    public DapperUserRepository(GeneralDbContext context)
    => _context = context;

    public Task<User> Update(User player)
    {
        throw new NotImplementedException();
    }

    public async Task<User> Save(User user)
    {
        using var connection = _context.CreateConnection();

        user.Id = Nanoid.Generate();

        var query = @$"INSERT INTO ""{_context.Account}"" VALUES (@Id, @Name, @Name, @Email, @HashedPassword, @Salt)";

        await connection.ExecuteAsync(query, user);

        var createdUser = await GetById(user.Id);

        return createdUser!;
    }

    public Task<User?> GetByEmail(string email)
      => throw new NotImplementedException();

    public async Task<User?> GetById(string id)
      => await _context.Account.Find(id);

    public Task DeleteById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> All()
    => _context.Account
               .Select(x => new { x.Id, x.Name })
               .All();
}
