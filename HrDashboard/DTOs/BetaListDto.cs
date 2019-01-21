using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrDashboard.DTOs
{
    public class BetaListDto
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateApplied { get; set; }
        public string AreaOfDesignation { get; set; }
        public string SourceOfApplication { get; set; }
        public string PositionApplied { get; set; }
        public string BusinessUnit { get; set; }
        public string Remarks { get; set; }
        public string WorkExp { get; set; }
        public string EducationalBg { get; set; }
        public string School { get; set; }
        public string InitialStatus { get; set; }
        public string HRScreening { get; set; }
        public string Examination { get; set; }
        public string DeptAssessment { get; set; }
        public string InitStatRemarks { get; set; }
        public string HrRemarks { get; set; }
        public string ExamRemarks { get; set; }
        public string DeptRemarks { get; set; }
    }
}