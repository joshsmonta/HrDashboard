using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrDashboard.Models
{
    public class Section
    {
        [Key]
        public int SectId { get; set; }
        public string SectName { get; set; }
        public int DeptId { get; set; }
        [JsonIgnore]
        public virtual Department Department { get; set; }
    }
}