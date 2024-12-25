using Npgsql;

namespace Infrastructure.Data;

public class DataContext
{
    private string connectionString = "Server=127.0.0.1;Port=5432;Database=book_db;User Id=postgres;Password=12345;";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connectionString);
    }
}