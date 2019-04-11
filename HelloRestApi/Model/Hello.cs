using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRestApi.Model
{
    public class Hello
    {
        public string Message { get; set; }
        public string Author { get; set; }

        public Hello(string message, string author)
        {
            Message = message;
            Author = author;
        }
    }
}
