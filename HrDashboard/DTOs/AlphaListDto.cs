using HrDashboard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrDashboard.DTOs
{
    public class AlphaListDto
    {
        public int Id { get; set; }
        public DateTime DateOfHire { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string CivilStatus { get; set; }
        public string PresentPosition { get; set; }
        public string Description { get; set; }
        public int JobGrade { get; set; }
        public double Allowances { get; set; }
        public double BasicSalary { get; set; }
        public double VLCredits { get; set; }
        public double SLCredits { get; set; }
        public string AreaOfAssignment { get; set; }
        public string EmploymentStatus { get; set; }
        public DateTime DateOfRegularization { get; set; }
        public string TemporaryId { get; set; }
        public string PermanentId { get; set; }
        public string PermanentAddress { get; set; }
        public string SSSNo { get; set; }
        public string PhilHealthNo { get; set; }
        public string HDMFNo { get; set; }
        public string PagibigNo { get; set; }
        public string TINNo { get; set; }
        public string ContactNumber { get; set; }
        public bool Active { get; set; }

        public int PosId { get; set; }
        [JsonIgnore]
        public virtual Position Position { get; set; }
    }
}