using Two.Application.Features.Users.Data;
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

        var query = @"INSERT INTO ""Account"" VALUES (@Id, @Name, @Name, @Email, @HashedPassword, @Salt)";

        await connection.ExecuteAsync(query, user);

        var createdUser = await GetById(user.Id);

        return createdUser!;
    }

    public Task<User?> GetByEmail(string email)
      => throw new NotImplementedException();

    public async Task<User?> GetById(string id)
    {
        using var connection = _context.CreateConnection();

        var query = @"SELECT * from ""Account"" WHERE Id = @Id";

        return await connection.QuerySingleOrDefaultAsync<User>(query, new { Id = id });
    }

    public Task DeleteById(string id)
    {
        throw new NotImplementedException();
    }
}
