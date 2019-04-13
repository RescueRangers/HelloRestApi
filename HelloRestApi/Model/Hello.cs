using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRestApi.Model
{
    public class Hello
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
        public DateTime TimeStamp { get; set; }

        public Hello()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
