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
    public class BusinessUnitController : ApiController
    {
        private HRContext context;
        public BusinessUnitController()
        {
            context = new HRContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public IEnumerable<BusinessUnitDto> GetBusinessUnits()
        {
            return context.BusinessUnits.ToList().Select(Mapper.Map<BusinessUnit, BusinessUnitDto>);
        }
    }
}
