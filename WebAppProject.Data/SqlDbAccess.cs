using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace WebAppProject.Data
{
    public class SqlDbAccess
    {
        private readonly IConfiguration config;

        public string ConnnectionStringName { get; set; } = "Default";

        public SqlDbAccess(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = this.config.GetConnectionString(ConnnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }

        
    }
}
