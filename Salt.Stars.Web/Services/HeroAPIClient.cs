using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Salt.Stars.Web.Models;
namespace Salt.Stars.Web.Services
{    public class HeroAPIClient : IHeroAPIClient 
    {
        private IConfiguration _configuration;

        public HeroAPIClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string createHeroUrl(int id)
        {
            var baseUrlForApi = _configuration["ApiBaseUrl"];
            return $"{baseUrlForApi}/hero/{id}";
        }

        private string createHeroesUrl()
        {
            var baseUrlForApi = _configuration["ApiBaseUrl"];
            return $"{baseUrlForApi}/HeroesPage";
        }

        public async Task<HeroResponse> GetHero(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

            var url = createHeroUrl(id);
            var heroTask = client.GetStreamAsync(url);

            var heroResult = await JsonSerializer.DeserializeAsync<HeroResponse>(await heroTask);
            return heroResult;
        }

        public async Task<HeroListResponse> GetHeroes()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

            var url = createHeroesUrl();
            var heroesTask = client.GetStreamAsync(url);

            var heroesResult = await JsonSerializer.DeserializeAsync<HeroListResponse>(await heroesTask);
            return heroesResult;
        }
    }
}

