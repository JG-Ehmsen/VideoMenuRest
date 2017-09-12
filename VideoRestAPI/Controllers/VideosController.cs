﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BLL.BO;
using System;

namespace VideoRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VideosController : Controller
    {
        BLLFacade facade = BLLFacade.GetInstance();

        // GET: api/Videos
        [HttpGet]
        public IEnumerable<VideoBO> Get()
        {
            return facade.VideoService.GetAll();
        }

        // GET: api/Videos/5
        [HttpGet("{id}", Name = "Get")]
        public VideoBO Get(int id)
        {
            return facade.VideoService.Get(id);
        }
        
        // POST: api/Videos
        [HttpPost]
        public IActionResult Post([FromBody]VideoBO vid)
        {
            if(!TryValidateModel(vid))
            {
                return BadRequest(ModelState.IsValid);
            }

            return Ok(facade.VideoService.Add(vid));
        }
        
        // PUT: api/Videos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]VideoBO vid)
        {
            if (id != vid.ID)
            {
                return BadRequest("Path ID does not match video ID in JSON object.");
            }
            try
            {
                return Ok(facade.VideoService.Update(vid));
            }
            catch(InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }

        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.VideoService.Delete(id);
        }
    }
}
