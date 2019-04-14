using HelloRestApi.Model;
using HelloRestApi.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRestApi.Hubs
{
    public class ChatHub : Hub
    {
        private readonly HelloRestApiContext _context;

        public ChatHub(HelloRestApiContext helloRestApiContext)
        {
            _context = helloRestApiContext;
        }

        //public async Task SendMessage(string user, string message)
        //{
        //    await _context.Hello.AddAsync(new Hello { Author = user, Message = message });

        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}

        public async Task SendMessage(Hello message)
        {
            await _context.Hello.AddAsync(message);

            await Clients.All.SendAsync("ReceiveMessage", message.Author, message.Message);
        }
    }
}
