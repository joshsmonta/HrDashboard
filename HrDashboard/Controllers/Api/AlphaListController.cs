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
    public class AlphaListController : ApiController
    {
        private HRContext context;
        public AlphaListController()
        {
            context = new HRContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public IEnumerable<AlphaListDto> GetAlphaList()
        {
            return context.AlphaLists.Where(a => a.Active == true).ToList().Select(Mapper.Map<AlphaList, AlphaListDto>);
        }

        [HttpGet]
        [Route("api/alphalist/allarchives")]
        public IEnumerable<AlphaListDto> GetArchive()
        {
            return context.AlphaLists.Where(a => a.Active == false).ToList().Select(Mapper.Map<AlphaList, AlphaListDto>);
        }

        [HttpGet]
        [Route("api/alphalist/byid/{posiId}")]
        public IHttpActionResult GetIdByPosId(int posiId)
        {
            var aTeam = context.AlphaLists.Single(a => a.PosId == posiId);
            if (aTeam == null)
            { return NotFound(); }

            return Ok(Mapper.Map<AlphaList, AlphaListDto>(aTeam));
        }

        [HttpGet]
        public IHttpActionResult GetAlphaMember(int id)
        {
            var aTeam = context.AlphaLists.Single(c => c.Id == id);
            if (aTeam == null)
            { return NotFound(); }

            return Ok(Mapper.Map<AlphaList, AlphaListDto>(aTeam));
        }

        [HttpPut]
        [Route("api/alphalist/edit/{id}")]
        public IHttpActionResult EditAlphaMember(int id, AlphaListDto alphaDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }

            var aTeam = context.AlphaLists.SingleOrDefault(c => c.Id == id);
            if (aTeam == null)
            { return NotFound(); }

            Mapper.Map(alphaDto, aTeam);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("api/alphalist/editPos/{posId}")]
        public IHttpActionResult EditPositionAlpha(int posId, AlphaListDto alphaDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }

            var aTeam = context.AlphaLists.SingleOrDefault(c => c.PosId == posId);
            if (aTeam == null)
            { return NotFound(); }

            Mapper.Map(alphaDto, aTeam);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("api/alphalist/archive/{id}")]
        public IHttpActionResult ArchiveMember(int id, AlphaListDto alphaDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }

            var aTeam = context.AlphaLists.SingleOrDefault(c => c.Id == id);
            if (aTeam == null)
            { return NotFound(); }

            aTeam.Active = alphaDto.Active;
            aTeam.PosId = null;
            context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult CreateAlphaMember(AlphaListDto alphaDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }

            var aTeam = Mapper.Map<AlphaListDto, AlphaList>(alphaDto);
            context.AlphaLists.Add(aTeam);
            context.SaveChanges();
            alphaDto.Id = aTeam.Id;

            return Created(new Uri(Request.RequestUri + "/" + alphaDto.Id), alphaDto);
        }
    }
}
