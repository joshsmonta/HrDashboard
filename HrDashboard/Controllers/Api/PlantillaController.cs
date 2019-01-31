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
    public class PlantillaController : ApiController
    {
        private HRContext context;
        public PlantillaController()
        { context = new HRContext();
        }

        protected override void Dispose(bool disposing)
        { context.Dispose(); }

        [Route("api/plantilla/update")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] PlantillaDto pDto)
        {
            var position = context.Positions.Single(c => c.PosId == pDto.PositionId);
            var employee = context.AlphaLists.Single(a => a.Id == pDto.EmployeeId);

            Plantilla plantilla = new Plantilla
            {
                Position = position,
                AlphaList = employee,
                DivId = position.DivId,
                DeptId = position.DeptId,
                SectId = position.SectId
            };
            context.Plantillas.Add(plantilla);
            context.SaveChanges();
            return Ok();
        }

        [Route("api/plantilla/dept/{deptId}")]
        [HttpGet]
        public IHttpActionResult GetPlantillaByDept(int deptId)
        {
            var query = (from a in context.AlphaLists
                         join p in context.Plantillas on a.PosId equals p.Position.PosId
                         where p.Position.DeptId == deptId
                         select new {
                             a.Id, a.FirstName, a.MiddleName, a.LastName, a.PresentPosition, p.Position.PosType, p.Position.BusinessUnit
                         });
            return Ok(query.ToList());
        }

        [Route("api/plantilla/deptunit/{deptId}/{unitId}")]
        [HttpGet]
        public IHttpActionResult GetPlantillaByDeptUnit(int deptId, int unitId)
        {
            var query = (from a in context.AlphaLists
                         join p in context.Plantillas on a.PosId equals p.Position.PosId
                         where p.Position.DeptId == deptId && p.Position.BUnit.unitId == unitId
                         select new
                         {
                             a.Id,
                             a.FirstName,
                             a.MiddleName,
                             a.LastName,
                             a.PresentPosition,
                             p.Position.PosType,
                             p.Position.BusinessUnit
                         });
            return Ok(query.ToList());
        }
        
        [Route("api/plantilla/dept/count/{deptId}")]
        [HttpGet]
        public IHttpActionResult GetNumbersByDept(int deptId)
        {
            var count = (from a in context.AlphaLists
                         join p in context.Plantillas on a.PosId equals p.Position.PosId
                         where p.Position.DeptId == deptId
                         select a).Count();
            return Ok(count);
        }

        [Route("api/plantilla/dept/vacant/{deptId}")]
        [HttpGet]
        public IHttpActionResult CountVacantPosInDept(int deptId)
        {
            var count = (from p in context.Positions
                         where p.DeptId == deptId && p.PosStatus == "Vacant"
                         select p).Count();
            return Ok(count);
        }

        [Route("api/plantilla/unit/count/{id}")]
        [HttpGet]
        public IHttpActionResult GetNumberByUnitId(int id)
        {
            var count = (from a in context.AlphaLists
                         join p in context.Plantillas on a.PosId equals p.Position.PosId
                         where p.Position.BUnit.unitId == id
                         select a).Count();
            return Ok(count);
        }
        
        //count all via business unit and division
        [Route("api/plantilla/divunit/count/{unitId}/{divId}")]
        [HttpGet]
        public IHttpActionResult GetNumberByUnitDivision(int unitId, int divId)
        {
            var count = (from a in context.AlphaLists
                         join p in context.Plantillas on a.PosId equals p.Position.PosId
                         where p.Position.BUnit.unitId == unitId && p.DivId == divId
                         select a).Count();
            return Ok(count);
        }

        [Route("api/plantilla/divhead/{divId}")]
        [HttpGet]
        public IHttpActionResult GetDivisionHead(int divId)
        {
            var divHead = (from a in context.AlphaLists
                           join p in context.Plantillas on a.PosId equals p.Position.PosId
                           where p.Position.DivId == divId && p.Position.PosType == "Division Head"
                           select new {
                               a.Id,
                               a.FirstName,
                               a.MiddleName,
                               a.LastName,
                               a.PresentPosition,
                               a.FileName,
                               p.Position.PosType,
                               p.Position.BusinessUnit
                           }).SingleOrDefault();
            return Ok(divHead);
        }

        //count all via business unit and dept
        [Route("api/plantilla/deptunit/count/{unitId}/{deptId}")]
        [HttpGet]
        public IHttpActionResult GetNumberByUnitDept(int unitId, int deptId)
        {
            var count = (from a in context.AlphaLists
                         join p in context.Plantillas on a.PosId equals p.Position.PosId
                         where p.Position.BUnit.unitId == unitId && p.DeptId == deptId
                         select a).Count();
            return Ok(count);
        }

        //count vacant positons via BU and Dept
        [Route("api/plantilla/deptunit/vacant/{unitId}/{deptId}")]
        [HttpGet]
        public IHttpActionResult GetUnitDeptVacant(int unitId, int deptId)
        {
            var count = (from p in context.Positions
                         where p.BUnit.unitId == unitId && p.DeptId == deptId && p.PosStatus == "Vacant"
                         select p).Count();
            return Ok(count);
        }

        //Count All Vacancy via business unit and Division
        [Route("api/plantilla/divunit/vacant/{unitId}/{divId}")]
        [HttpGet]
        public IHttpActionResult GetByUnitDivVacant(int unitId, int divId)
        {
            var count = (from p in context.Positions
                         where p.BUnit.unitId == unitId && p.DivId == divId && p.PosStatus == "Vacant"
                         select p).Count();
            return Ok(count);
        }
        
        [HttpDelete]
        public IHttpActionResult DeletePlant(int id)
        {
            var plantilla = context.Plantillas.SingleOrDefault(p => p.AlphaList.Id == id);
            if (plantilla == null)
            { return NotFound(); }

            context.Plantillas.Remove(plantilla);
            context.SaveChanges();
            return Ok();
        }
    }
}
