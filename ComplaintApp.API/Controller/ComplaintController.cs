using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComplaintApp.API.Helper;
using ComplaintApp.API.Model;
using ComplaintApp.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintApp.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintService _complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        [Authorize]
        [HttpGet("GetAllComplaint")]
        public IActionResult GetAllComplaint()
        {
            if (_complaintService == null)
                return BadRequest();

            return Ok(_complaintService.GetAllComplaint());
        }

        [Authorize]
        [HttpPost("AddComplaint")]
        public IActionResult AddComplaint(Complaint complaintModel)
        {
            if (complaintModel == null ||_complaintService == null)
                return BadRequest();

            complaintModel.ComplaintBy = Convert.ToInt32(Utility.GetSpecificClaim(User.Identities.FirstOrDefault(), "UserId"));

            return Ok(_complaintService.AddComplaint(complaintModel));
        }

    }
}