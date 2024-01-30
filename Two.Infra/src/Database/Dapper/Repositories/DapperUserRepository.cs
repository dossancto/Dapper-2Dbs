using Two.Application.Features.Users.Data;
using Two.Infra.Database.Dapper.Utils;
using EntityDapper.Queries;
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

        var query = @$"INSERT INTO ""{_context.Account.TableName}"" VALUES (@Id, @Name, @Name, @Email, @HashedPassword, @Salt)";

        // _context.Account
        //         .Insert(x => new { x.Id })
        //         .Values(new { Id = "dasda" });

        // _context.Account
        //         .Insert()
        //         .Values(user);

        // _context.Account
        //         .InsertWithPk()
        //         .Values(user);

        await connection.ExecuteAsync(query, user);

        var createdUser = (await _context.Account
               .Select(x => new { x.Id, x.Name, x.Email, x.Salt })
               .Where(x => x.Id == user.Id)
               .FindAll())
               .FirstOrDefault();

        return createdUser!;
    }

    public async Task<User?> GetByEmail(string email)
    => (await _context.Account
               .Select(x => new { x.Id })
               .Where(x => x.Email == email)
               .FindAll())
               .FirstOrDefault();

    public async Task<User?> GetById(string id)
    => (await _context.Account
               .Select(x => new { x.Id })
               .Where(x => x.Id == id)
               .FindAll()).FirstOrDefault();

    public Task DeleteById(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> All()
    => await _context.Account
               .Select(x => new { x.Id, x.Email })
               .FindAll();

    // EXAMPLE:
    // =================
    // public async Task<IEnumerable<User>> All()
    // => await _context.Account
    //            .Select(x => new { x.Id, x.Email })
    //            .Where(x => x.Id == "Ey7Y_uX7sZnJ11ni391GD")
    //            .Where(x => x.Email == "test@test.com")
    //            .FindAll();

    // Generated SQL
    // ==================
    // SELECT Id, Email
    // FROM "Account"
    // WHERE Id = 'Ey7Y_uX7sZnJ11ni391GD'
    // AND Email = 'test@test.com'
}
