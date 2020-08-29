using System.Threading.Tasks;
using System.Collections.Generic;
using System;
namespace tour_of_heroes.Services
{
    public interface IMessagingService
    {
        Task Add(string Message);
        Task Clear();
        List<string> Get();
       event EventHandler<List<string>> OnMessagesChanged;
      //  event List<string> Messages {get; set;}
    }
}