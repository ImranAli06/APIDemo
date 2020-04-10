using ComplaintApp.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApp.API.Repository
{
    public class ComplaintRepository : BaseRepository<Complaint>, IComplaintRepository
    {
        public ComplaintRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
