using Two.Application.Features.Users.Entities;
using Two.Infra.Database.Dapper.Contexts.Base;
using Two.Infra.Database.Dapper.Utils;

namespace Two.Infra.Database.Dapper.Contexts;

public class GeneralDbContext(DapperDbConfiguration configuration) : DapperContext(configuration)
{
    public DbTable<User> Account => new(this, tableName: "Account");
}

