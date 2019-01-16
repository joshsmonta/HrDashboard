using HrDashboard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrDashboard.DTOs
{
    public class PositionDto
    {
        public int PosId { get; set; }
        public string PosType { get; set; }
        public string PosName { get; set; }
        public string PosStatus { get; set; }
        public string InDivision { get; set; }
        public string InDept { get; set; }
        public string InSection { get; set; }
        public int DivId { get; set; }
        public int DeptId { get; set; }
        public int SectId { get; set; }
        public bool Head { get; set; }
        public string BusinessUnit { get; set; }
        public BusinessUnit BUnit { get; set; }

        [JsonIgnore]
        public virtual Division Division { get; set; }
        [JsonIgnore]
        public virtual Department Department { get; set; }
        [JsonIgnore]
        public virtual Section Section { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<AlphaList> AlphaLists { get; set; }
    }
}