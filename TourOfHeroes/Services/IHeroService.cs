using tour_of_heroes.Models;
using System.Threading.Tasks;
public interface IHeroService
{
    Task<Hero[]> GetHeroes();
}
