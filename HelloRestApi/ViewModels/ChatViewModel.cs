using HelloRestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRestApi.ViewModels
{
    public class ChatViewModel
    {
        public IEnumerable<Hello> Helloes { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
    }
}
