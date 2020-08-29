using tour_of_heroes.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace tour_of_heroes.Services
{
    public class HeroService : IHeroService
    {
        private readonly HttpClient Http;
        private readonly IMessagingService _MessagingService;

        public HeroService(HttpClient client, IMessagingService messagingService)
        {
            Http = client;
            _MessagingService = messagingService;
        }
        public async Task<Hero[]> GetHeroes()
        {
            await _MessagingService.Add("Heroes Service: Heroes Fetched");
            return await Http.GetFromJsonAsync<Hero[]>("sample-data/heroes.json");
        }
    }
}