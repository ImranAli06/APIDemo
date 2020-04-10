using ComplaintApp.API.Helper;
using ComplaintApp.API.Model;
using ComplaintApp.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComplaintApp.API.Service
{
    public class ComplaintService : IComplaintService
    {
        private readonly IComplaintRepository _complaintRepository;

        public ComplaintService(IComplaintRepository complaintRepository
           )
        {
            _complaintRepository = complaintRepository;
        }

        public DataTransfer<List<Complaint>> GetAllComplaint() {
            var complaintList = new List<Complaint>();
            try
            {
                complaintList = _complaintRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return Response.GetFailedResponse(complaintList, ex.Message);
            }

            if (complaintList.Count > 0)
            {
                return Response.GetSuccessResponse(complaintList, "Success.");
            }
            else
            {
                return Response.GetNotFoundResponse(complaintList, "Error.");
            }
        }

        public DataTransfer<Boolean> AddComplaint(Complaint complaintModel)
        {
            int complaintId = 0;
            
            try {
                complaintId = _complaintRepository.Insert(complaintModel);
            }
            catch (Exception ex)
            {
                return Response.GetFailedResponse(false, ex.Message);
            }

            if (complaintId > 0)
            {
                return Response.GetSuccessResponse(true, "Success.");
            }
            else
            {
                return Response.GetNotFoundResponse(false, "Error.");
            }
        }

    }
}
