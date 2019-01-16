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
    public class DepartmentController : ApiController
    {
        private HRContext context;
        public DepartmentController()
        {
            context = new HRContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public IEnumerable<DepartmentDto> GetDepartments()
        {
            return context.Departments.ToList().Select(Mapper.Map<Department, DepartmentDto>);
        }

        [HttpGet]
        public IEnumerable<DepartmentDto> GetDeptItem(int id)
        {
            var dept = context.Departments.Where(c => c.DivId == id)
                .ToList()
                .Select(Mapper.Map<Department, DepartmentDto>);
            
            return dept;
        }

        [HttpGet]
        [Route("api/department/name/{deptId}")]
        public IHttpActionResult GetDeptName(int deptId)
        {
            var dept = context.Departments.Single(d => d.DeptId == deptId);
            if (dept == null)
            { return NotFound(); }

            return Ok(Mapper.Map<Department, DepartmentDto>(dept));
        }
    }
}
