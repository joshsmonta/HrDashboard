using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrDashboard.Models
{
    public class BusinessUnit
    {
        [Key]
        public int unitId { get; set; }
        public string unitName { get; set; }

        public ICollection<Position> Positions { get; set; }
    }
}