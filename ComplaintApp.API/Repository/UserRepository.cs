using ComplaintApp.API.Model;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApp.API.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public User GetLoginCredentials(string userName, string password)
        {
            var Predicate = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            Predicate.Predicates.Add(Predicates.Field<User>(f => f.UserName, Operator.Eq, userName));
            Predicate.Predicates.Add(Predicates.Field<User>(f => f.Password, Operator.Eq, password));

            return DbConnection.GetList<User>(Predicate).ToList().FirstOrDefault();
        }
    }
}
