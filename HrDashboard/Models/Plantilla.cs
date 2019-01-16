using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrDashboard.Models
{
    public class Plantilla
    {
        [Key]
        public int Id { get; set; }
        
        public int DivId { get; set; }
        public int DeptId { get; set; }
        public int SectId { get; set; }

        [Required]
        public Position Position { get; set; }
        [Required]
        public AlphaList AlphaList { get; set; }
    }
}