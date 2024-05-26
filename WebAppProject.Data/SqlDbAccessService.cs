using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace WebAppProject.Data
{
    public class SqlDbAccessService : ISqlDbAccessService
    {
        private readonly IConfiguration config;

        public string ConnnectionStringName { get; set; } = "DefaultConnection";

        public SqlDbAccessService(IConfiguration config)
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

        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = this.config.GetConnectionString(ConnnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
