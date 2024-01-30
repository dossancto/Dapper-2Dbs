namespace EntityDapper.Configuration;

public class DapperDbConfiguration
{
    public string? Connectionstring { get; set; }
    public string? ConnectionstringEnv { get; set; } = string.Empty;

    internal string? ConnectionStringFromEnv()
      => ConnectionstringEnv is not null
          ? Environment.GetEnvironmentVariable(ConnectionstringEnv) ?? throw new ArgumentException($"{ConnectionstringEnv} not found.")
          : null;
}
