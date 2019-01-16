using HrDashboard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrDashboard.DTOs
{
    public class BusinessUnitDto
    {
        [Key]
        public int unitId { get; set; }
        public string unitName { get; set; }

        [JsonIgnore]
        public ICollection<Position> Positions { get; set; }
    }
}