using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrDashboard.DTOs
{
    public class LogbookDto
    {
        public int LogId { get; set; }
        public DateTime LogDate { get; set; }
        public string LogType { get; set; }

        public int? Id { get; set; }
    }
}