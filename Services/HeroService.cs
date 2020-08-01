using tour_of_heroes.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Linq;

namespace tour_of_heroes.Services
{
    public class HeroService : IHeroService
    {
        private readonly HttpClient Http;
        private readonly IMessagingService _MessagingService;
        private Hero[] heroes;
        public HeroService(HttpClient client, IMessagingService messagingService)
        {
            Http = client;
            _MessagingService = messagingService;
        }
        public async Task<Hero[]> GetHeroes()
        {
            if(heroes == null){
                await _MessagingService.Add("Heroes Service: Heroes Fetched");
                heroes = await Http.GetFromJsonAsync<Hero[]>("sample-data/heroes.json");
            }

            return heroes;
        }
        public async Task<Hero[]> Add(string HeroName)
        {
            
            var heroList = new List<Hero>(heroes);
            var sortedIndexes = heroList.OrderByDescending(x=>x.Id);
            var currentIndex = sortedIndexes.First().Id;
            var newHero = new Hero(){Name = HeroName, Id=++currentIndex};
            heroList.Add(newHero);
            heroes = await Task.Factory.StartNew(() => heroList.ToArray());
            return heroes;
        }

        public async Task<Hero[]> Delete(Hero hero)
        {
            
            heroes = await Task.Factory.StartNew(() =>
                heroes.Where(x => x != hero).ToArray()
            );
            
            return heroes;
        }

        public Hero[] Search(string text)
        {         
            return heroes.Where(x => x.Name.ToLower()
                .Contains(text.Trim().ToLower())).ToArray();

        }

    }
}