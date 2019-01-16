using AutoMapper;
using HrDashboard.DTOs;
using HrDashboard.ModelInitialize;
using HrDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HrDashboard.Controllers.Api
{
    public class SectionController : ApiController
    {
        private HRContext context;
        public SectionController()
        {
            context = new HRContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public IEnumerable<SectionDto> GetSections()
        {
            return context.Sections.ToList().Select(Mapper.Map<Section, SectionDto>);
        }

        [HttpGet]
        public IEnumerable<SectionDto> GetSectionItems(int id)
        {
            var sect = context.Sections.Where(c => c.DeptId == id)
                .ToList()
                .Select(Mapper.Map<Section, SectionDto>);

            return sect;
        }
    }
}
