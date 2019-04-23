using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrDashboard.Models
{
    public class SRFRequest
    {
        [Key]
        public int ReqId { get; set; }
        public string ReqPosition { get; set; }
        public string PosDiv { get; set; }
        public string PosDept { get; set; }
        public string PosSect { get; set; }
        public int Quantity { get; set; }
        public string PersonToReplace { get; set; }
        public bool Temporary { get; set; }
        public int DurationInYears { get; set; }
        public int DurationInMonths { get; set; }
        public string RequestedBy { get; set; }
        public string ReviewedBy { get; set; }
        public bool Reviewed { get; set; }
        public string ApprovedBy { get; set; }
        public bool Approved { get; set; }
    }
}