using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
// using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace tour_of_heroes.Services
{
    public class MessagingService : IMessagingService
    {
        public List<string> Messages { get; set; } = new List<string>();

        public event EventHandler<List<string>> OnMessagesChanged;

        public List<string> Get() => Messages;
        public async Task Add(string message)
        {
            await Task.Factory.StartNew(() => Messages.Add(message));
            OnMessagesChanged?.Invoke(this, Messages);
        }
        public async Task Clear()
        {
            await Task.Factory.StartNew(() => Messages.Clear());
             OnMessagesChanged?.Invoke(this, Messages);
        }
    }
}