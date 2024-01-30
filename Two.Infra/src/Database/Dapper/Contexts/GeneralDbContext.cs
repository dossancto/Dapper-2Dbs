using EntityDapper.Configuration;
using EntityDapper.Contexts;
using EntityDapper.Tables;
using Two.Application.Features.Users.Entities;

namespace Two.Infra.Database.Dapper.Contexts;

public class GeneralDbContext(DapperDbConfiguration configuration) : DapperContext(configuration)
{
    public TableSet<User> Account => new(this, tableName: "Account");
}

