﻿using HrDashboard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrDashboard.Models
{
    public class Position
    {
        [Key]
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


        public int unitId { get; set; }
        [JsonIgnore]
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