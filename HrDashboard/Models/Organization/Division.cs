using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrDashboard.Models
{
    public class Division
    {
        [Key]
        public int DivId { get; set; }
        public string DivName { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Department> Departments { get; set; }
    }
}