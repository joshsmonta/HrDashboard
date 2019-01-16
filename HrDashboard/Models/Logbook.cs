using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrDashboard.Models
{
    public class Logbook
    {
        [Key]
        public int LogId { get; set; }
        public DateTime LogDate { get; set; }
        public string LogType { get; set; }
        
        public int? Id { get; set; }
    }
}