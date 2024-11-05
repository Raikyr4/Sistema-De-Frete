using System.Data;
using Npgsql; // Driver para PostgreSQL

public static class ConfigBanco
{
    private const string ConnectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=12345";

    public static IDbConnection GetConnection()
    {
        return new NpgsqlConnection(ConnectionString);
    }
}
