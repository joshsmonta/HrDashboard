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
    public class BetaListController : ApiController
    {
        private HRContext context;
        public BetaListController()
        {
            context = new HRContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public IEnumerable<BetaListDto> GetBetaList()
        {
            return context.BetaLists.ToList().Select(Mapper.Map<BetaList, BetaListDto>);
        }

        [HttpGet]
        public IHttpActionResult GetBetaMember(int id)
        {
            var bTeam = context.BetaLists.Single(c => c.Id == id);
            if (bTeam == null)
            { return NotFound(); }

            return Ok(Mapper.Map<BetaList, BetaListDto>(bTeam));
        }

        [HttpPut]
        public IHttpActionResult EditBetaMember(int id, BetaListDto betaListDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }

            var bTeam = context.BetaLists.SingleOrDefault(c => c.Id == id);
            if (bTeam == null)
            { return NotFound(); }

            bTeam.InitialStatus = betaListDto.InitialStatus;
            bTeam.HRScreening = betaListDto.HRScreening;
            bTeam.DeptAssessment = betaListDto.DeptAssessment;
            bTeam.Examination = betaListDto.Examination;
            context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult CreateNewBetaMember(BetaListDto betaDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }

            var bTeam = Mapper.Map<BetaListDto, BetaList>(betaDto);
            context.BetaLists.Add(bTeam);
            context.SaveChanges();
            betaDto.Id = bTeam.Id;

            return Created(new Uri(Request.RequestUri + "/" + betaDto.Id), betaDto);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMember(int id)
        {
            var bTeam = context.BetaLists.Single(c => c.Id == id);
            if (bTeam == null)
            { return NotFound(); }

            context.BetaLists.Remove(bTeam);
            context.SaveChanges();
            return Ok();
        }
    }
}
