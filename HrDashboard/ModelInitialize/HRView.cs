using HrDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HrDashboard.ModelInitialize
{
    public class HRContext : DbContext
    {
        public DbSet<AlphaList> AlphaLists { get; set; }
        public DbSet<Users> UsersDbSet { get; set; }
        public DbSet<BetaList> BetaLists { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Plantilla> Plantillas { get; set; }
        public DbSet<Logbook> Logbooks { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }

        public HRContext() : base("name=HRContext") { }
    }
}