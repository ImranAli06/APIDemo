using ComplaintApp.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApp.API.Service
{
    public interface IComplaintService
    {
        DataTransfer<List<Complaint>> GetAllComplaint();
        DataTransfer<Boolean> AddComplaint(Complaint complaintModel);
    }
}
