using HelloRestApi.Hubs;
using HelloRestApi.Model;
using HelloRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly HelloRestApiContext _context;

        public HelloController (HelloRestApiContext context)
        {
            _context = context;
        }

        // GET api/hello
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hello>>> GetHello()
        {
            var messeges = await _context.Hello.ToListAsync();
            return Ok(messeges);
        }

        // GET api/hello/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hello>> Get(int id)
        {
            var message = await _context.Hello.FirstOrDefaultAsync(m => m.ID == id);

            if (message == null)
            {
                return StatusCode(400, "Bad request");
            }

            return Ok(message);
        }

        // POST api/hello
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Hello value)
        {
            if (ModelState.IsValid)
            {
                _context.Hello.Add(value);
                await _context.SaveChangesAsync();
            }
            return Created(new Uri(Request.Path + "/" + (_context.Hello.Last().ID).ToString(),UriKind.Relative),value);
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
