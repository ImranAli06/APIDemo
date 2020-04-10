using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComplaintApp.API.Model
{
    public class Complaint:BaseEntity
    {
        public int ComplaintId { get; set; }
        public string ComplaintTitle { get; set; }
        public string ComplaintDetail { get; set; }
        public int ComplaintBy { get; set; }
    }
}