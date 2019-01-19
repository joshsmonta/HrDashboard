using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrDashboard.Models
{
    public class BetaList
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "First Name: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string FName { get; set; }

        [Display(Name = "Middle Name: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string MName { get; set; }

        [Display(Name = "Last Name: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string LName { get; set; }

        [Display(Name = "E-mail: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string Email { get; set; }

        [Display(Name = "Contact No: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string ContactNumber { get; set; }

        [Display(Name = "Date of Birth: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Date of Applied: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public DateTime DateApplied { get; set; }

        [Display(Name = "Area of Designation: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string AreaOfDesignation { get; set; }

        [Display(Name = "Source of Application: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string SourceOfApplication { get; set; }

        [Display(Name = "Position Applied: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string PositionApplied { get; set; }

        [Display(Name = "Business Unit: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string BusinessUnit { get; set; }

        [Display(Name = "Work Experience: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string WorkExp { get; set; }

        [Display(Name = "Education: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string EducationalBg { get; set; }

        [Display(Name = "School: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string School { get; set; }

        [Display(Name = "Remarks: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string Remarks { get; set; }

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