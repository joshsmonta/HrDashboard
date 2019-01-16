using HrDashboard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrDashboard.DTOs
{
    public class SectionDto
    {
        public int SectId { get; set; }
        public string SectName { get; set; }


        public int DeptId { get; set; }
        [JsonIgnore]
        public virtual Department Department { get; set; }
    }
}