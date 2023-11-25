using System.Data.SqlClient;

namespace DapperCrudOperations.Services;

public class SqlConnectionFactory(string connectionString)
{
    private readonly string _connectionString = connectionString;

    public SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);    
    }
}