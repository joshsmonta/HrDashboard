using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrDashboard.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        
        public int DivId { get; set; }
        [JsonIgnore]
        public virtual Division Division { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Section> Sections { get; set; }
    }
}