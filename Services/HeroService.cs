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

        public HeroService(HttpClient client)
        {
            Http = client;
        }
        public async Task<Hero[]> GetHeroes()
        {
            return await Http.GetFromJsonAsync<Hero[]>("sample-data/heroes.json");
        }
    }
}