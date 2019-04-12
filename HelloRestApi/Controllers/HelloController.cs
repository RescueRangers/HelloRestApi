using HelloRestApi.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        private static List<Hello> _messeges = new List<Hello>();

        // GET api/hello
        [HttpGet]
        public ActionResult<IEnumerable<Hello>> GetHello()
        {
            return Ok(_messeges);
        }

        // GET api/hello/5
        [HttpGet("{id}")]
        public ActionResult<Hello> Get(int id)
        {
            if (_messeges.Count < id+1)
            {
                return StatusCode(400, "Bad request");
            }

            return Ok(_messeges[id]);
        }

        // POST api/hello
        [HttpPost]
        public ActionResult Post([FromBody] Hello value)
        {
            _messeges.Add(value);
            return Created(new Uri(Request.Path + "/" + (_messeges.Count-1).ToString(),UriKind.Relative),value);
        }

        // PUT api/hello/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            return StatusCode(400, "Bad request");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return StatusCode(400, "Bad request");
        }
    }
}
