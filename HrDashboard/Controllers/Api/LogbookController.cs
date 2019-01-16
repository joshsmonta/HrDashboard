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
    public class LogbookController : ApiController
    {
        private HRContext context;
        public LogbookController()
        {
            context = new HRContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        [HttpGet]
        public IEnumerable<LogbookDto> GetLogs()
        {
            return context.Logbooks.ToList().Select(Mapper.Map<Logbook, LogbookDto>);
        }

        public IEnumerable<LogbookDto> GetLog(int id)
        {
            return context.Logbooks.Where(l => l.Id == id).ToList().Select(Mapper.Map<Logbook, LogbookDto>);
        }

        [HttpPost]
        [Route("api/logbook/new")]
        public IHttpActionResult CreateNewLog(LogbookDto logDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }

            var logs = Mapper.Map<LogbookDto, Logbook>(logDto);
            context.Logbooks.Add(logs);
            context.SaveChanges();
            logDto.LogId = logs.LogId;

            return Created(new Uri(Request.RequestUri + "/" + logDto.LogId), logDto);
        }
    }
}
