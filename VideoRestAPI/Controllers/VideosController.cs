using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BLL.BO;

namespace VideoRestAPI.Controllers
{
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
        [HttpGet("{id}", Name = "Get")]
        public VideoBO Get(int id)
        {
            return facade.VideoService.Get(id);
        }
        
        // POST: api/Videos
        [HttpPost]
        public void Post([FromBody]VideoBO vid)
        {
            facade.VideoService.Add(vid);
        }
        
        // PUT: api/Videos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]VideoBO vid)
        {
            facade.VideoService.Update(vid);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.VideoService.Delete(id);
        }
    }
}
