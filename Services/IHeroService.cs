using tour_of_heroes.Models;
using System.Threading.Tasks;
public interface IHeroService
{
    Task<Hero[]> GetHeroes();
    Task<Hero[]> Add(string HeroName);
    Task<Hero[]> Delete(Hero hero);
    Hero[] Search(string text);
}
