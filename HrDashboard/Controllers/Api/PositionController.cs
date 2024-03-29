﻿using AutoMapper;
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
    public class PositionController : ApiController
    {
        private HRContext context;
        public PositionController()
        { context = new HRContext(); }

        protected override void Dispose(bool disposing)
        { context.Dispose(); }
        //api/position/
        public IEnumerable<PositionDto> GetPositions(string query = null)
        {
            var positionQuery = context.Positions.ToList().Select(Mapper.Map<Position, PositionDto>);
            var status = "Vacant";

            if (!string.IsNullOrWhiteSpace(query))
            {
                positionQuery = context.Positions.Where(c => c.PosName.Contains(query) && c.PosStatus == status)
                    .ToList()
                    .Select(Mapper.Map<Position, PositionDto>);
            }
            return positionQuery;
        }

        [Route("api/position/select/{posId}")]
        [HttpGet]
        public IHttpActionResult GetVacantPosition(int posId)
        {
            var position = context.Positions.SingleOrDefault(p => p.PosId == posId);
            if (position == null)
            { return NotFound(); }
            return Ok(Mapper.Map<Position, PositionDto>(position));
        }

        //get all vacant position by unitId
        [Route("api/position/unit/vacant/{id}")]
        [HttpGet]
        public IHttpActionResult GetVacancyByUnitId(int id)
        {
            var count = (from p in context.Positions
                         where p.BUnit.unitId == id && p.PosStatus == "Vacant"
                         select p).Count();
            return Ok(count);
        }
        //get all vacant position via deptId
        [Route("api/position/dept/openpos/{deptId}")]
        [HttpGet]
        public IHttpActionResult GetVacantByDept(int deptId)
        {
            var query = (from p in context.Positions
                         where p.DeptId == deptId && p.PosStatus == "Vacant"
                         select p);
            return Ok(query.ToList());
        }
        //get all vacant position via deptId
        [Route("api/position/deptunit/openpos/{deptId}/{unitId}")]
        [HttpGet]
        public IHttpActionResult GetVacantByDeptUnit(int deptId, int unitId)
        {
            var query = (from p in context.Positions
                         where p.DeptId == deptId && p.BUnit.unitId == unitId && p.PosStatus == "Vacant"
                         select p);
            return Ok(query.ToList());
        }

        [HttpGet]
        [Route("api/position/status/{stat}")]
        public IEnumerable<PositionDto> ByStatus(string stat)
        {
            var activePos = context.Positions.Where(c => c.PosStatus == stat)
                .ToList()
                .Select(Mapper.Map<Position, PositionDto>);
            return activePos;
        }

        //All Division Position Chart
        [HttpGet]
        [Route("api/position/allposperdiv")]
        public IHttpActionResult GetAllPositionPerDiv()
        {
            var position = (from p in context.Positions
                            group p by p.DivId into g
                            select new
                            {
                                divIds = g.Key,
                                count = g.Count()
                            });
            return Ok(position);
        }

        //Position Pie Chart
        [HttpGet]
        [Route("api/position/allstatus")]
        public IHttpActionResult GetAllPositionStatus()
        {
            var query = (from p in context.Positions
                        group p by p.PosStatus into g
                        select new
                        {
                            posStatus = g.Key,
                            count = g.Count() 
                        });
            return Ok(query);
        }

        //For BU Pie Chart
        [HttpGet]
        [Route("api/position/countallbybu")]
        public IHttpActionResult CountAllByBu()
        {
            var query = (from p in context.Positions
                        group p by p.BusinessUnit into g
                        select new
                        {
                            units = g.Key,
                            count = g.Count()
                        });
            return Ok(query);
        }

        [HttpPut]
        [Route("api/position/edit/{id}")]
        public IHttpActionResult EditPos(int id, PositionDto posDto)
        {
            if(!ModelState.IsValid)
            { return BadRequest(); }

            var pos = context.Positions.SingleOrDefault(p => p.PosId == id);
            if(pos == null)
            { return NotFound(); }

            Mapper.Map(posDto, pos);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EditPosition(int id, PositionDto posDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }

            var pos = context.Positions.SingleOrDefault(c => c.PosId == id);
            if (pos == null)
            { return NotFound(); }

            pos.PosStatus = posDto.PosStatus;
            context.SaveChanges();

            return Ok();
        }
        
        [HttpPost]
        public IHttpActionResult CreatePosition(PositionDto posDto)
        {
            if (posDto == null)
            { return BadRequest(); }

            var pos = Mapper.Map<PositionDto, Position>(posDto);
            context.Positions.Add(pos);
            context.SaveChanges();
            posDto.PosId = pos.PosId;

            return Created(new Uri(Request.RequestUri + "/" + posDto.PosId), posDto);
        }

        [HttpDelete]
        public IHttpActionResult DeletePosition(int id)
        {
            var position = context.Positions.SingleOrDefault(c => c.PosId == id);
            if (position == null)
            { return NotFound(); }

            context.Positions.Remove(position);
            context.SaveChanges();
            return Ok();
        }
    }
}
