using ComplaintApp.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using DapperExtensions;

namespace ComplaintApp.API.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity

    {
        private const string ActiveCondition = "WHERE IsActive = 1";
        protected readonly IDbConnection DbConnection;

        public BaseRepository(string connectionString)
        {
            DbConnection = new SqlConnection(connectionString);
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.SqlServerDialect();

        }

        public IEnumerable<T> GetAll(bool includeRemoved)
        {
            return includeRemoved ? DbConnection.GetList<T>() : DbConnection.GetList<T>().Where(x => x.IsActive == true);
        }
        
        public int Insert(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            return DbConnection.Insert<T>(entity) ?? 0;
        }
    }
}
