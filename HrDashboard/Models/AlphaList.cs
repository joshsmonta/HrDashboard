using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrDashboard.Models
{
    public class AlphaList
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Date of Hire: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public DateTime DateOfHire { get; set; }

        [Display(Name = "First Name:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Sex:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string Sex { get; set; }

        [Display(Name = "Civil Status:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string CivilStatus { get; set; }

        [Display(Name = "Present Position:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string PresentPosition { get; set; }

        [Display(Name = "Description:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string Description { get; set; }

        [Display(Name = "Job Grade: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public int JobGrade { get; set; }

        [Display(Name = "Allowances:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public double Allowances { get; set; }

        [Display(Name = "Basic Salary:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public double BasicSalary { get; set; }

        [Display(Name = "VL Credits:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public double VLCredits { get; set; }

        [Display(Name = "SL Credits:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public double SLCredits { get; set; }

        [Display(Name = "Area of Assignment:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string AreaOfAssignment { get; set; }

        [Display(Name = "Employment Status:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string EmploymentStatus { get; set; }

        [Display(Name = "Date of Regularization:")]
        public DateTime? DateOfRegularization { get; set; }

        [Display(Name = "TemporaryID:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required, If Employee does not have TempID, then encode with zeros.")]
        public string TemporaryId { get; set; }

        [Display(Name = "PermanentID:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required, If Employee does not have PermanentID, then encode with zeros.")]
        public string PermanentId { get; set; }

        [Display(Name = "Address:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string PermanentAddress { get; set; }

        [Display(Name = "SSS ID Number: ")]
        public string SSSNo { get; set; }

        [Display(Name = "Phil Health ID: ")]
        public string PhilHealthNo { get; set; }

        [Display(Name = "HDMF Number: ")]
        public string HDMFNo { get; set; }

        [Display(Name = "Pagibig ID: ")]
        public string PagibigNo { get; set; }

        [Display(Name = "TIN Number:")]
        public string TINNo { get; set; }

        [Display(Name = "Contact Number:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required.")]
        public string ContactNumber { get; set; }
         
        public bool Active { get; set; }

        public string FileName { get; set; }

        public int? PosId { get; set; }
        [JsonIgnore]
        public virtual Position Position { get; set; }
    }
}