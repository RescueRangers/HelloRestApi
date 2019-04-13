using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelloRestApi.Model;

namespace HelloRestApi.Models
{
    public class HelloRestApiContext : DbContext
    {
        public HelloRestApiContext (DbContextOptions<HelloRestApiContext> options)
            : base(options)
        {
        }

        public DbSet<Hello> Hello { get; set; }
    }
}
