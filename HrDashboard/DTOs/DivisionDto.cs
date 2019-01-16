using HrDashboard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrDashboard.DTOs
{
    public class DivisionDto
    {
        public int DivId { get; set; }
        public string DivName { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Department> Departments { get; set; }
    }
}