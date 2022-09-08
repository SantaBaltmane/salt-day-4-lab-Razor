using System.Threading.Tasks;
using Salt.Stars.Web.Models;

namespace Salt.Stars.Web.Services
{
    public interface IHeroAPIClient
    {
        Task<HeroResponse> GetHero(int id);

        Task<HeroListResponse> GetHeroes();
    }
}
