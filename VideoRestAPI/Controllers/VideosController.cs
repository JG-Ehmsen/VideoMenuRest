using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BLL.BO;
using System;
using Microsoft.AspNetCore.Cors;

namespace VideoRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VideosController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/Videos
        [HttpGet]
        public IEnumerable<VideoBO> Get()
        {
            return facade.VideoService.GetAll();
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Vid = facade.VideoService.Get(id);
            if (Vid == null)
            {
                return StatusCode(404, "No video found.");
            }
            else
                return Ok(Vid);
        }
        
        // POST: api/Videos
        [HttpPost]
        public IActionResult Post([FromBody]VideoBO vid)
        {
            if (!TryValidateModel(vid))
            {
                return BadRequest(ModelState.IsValid);
            }
            var video = facade.VideoService.Add(vid);
            if (video != null)
                return Ok(video);
            else
                return BadRequest("ID already exists.");
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
        public IActionResult Delete(int id)
        {
            var vid = facade.VideoService.Delete(id);
            if (vid != null)
            {
                return Ok(vid);
            }
            else
                return StatusCode(404, "No video found with that ID");
        }
    }
}
