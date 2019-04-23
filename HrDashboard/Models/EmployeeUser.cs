using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrDashboard.Models
{
    public class EmployeeUser
    {
        [Key]
        public int EmpId { get; set; }
        public string FullName { get; set; }
        public string EmpUsername { get; set; }
        public string EmpPassword { get; set; }
        public string EmpConfirmPassword { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public System.Guid ActivationCode { get; set; }
    }
}