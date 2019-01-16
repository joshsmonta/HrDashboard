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
    public class DivisionController : ApiController
    {
        private HRContext context;
        public DivisionController()
        {
            context = new HRContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        //api/division
        [HttpGet]
        public IEnumerable<DivisionDto> GetDivisons()
        {
            return context.Divisions.ToList().Select(Mapper.Map<Division, DivisionDto>);
        }
    }
}
