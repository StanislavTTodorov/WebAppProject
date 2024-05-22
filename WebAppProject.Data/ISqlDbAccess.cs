
namespace WebAppProject.Data
{
    public interface ISqlDbAccess
    {
        string ConnnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
    }
}