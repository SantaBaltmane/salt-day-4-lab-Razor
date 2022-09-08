using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Salt.Stars.Web.Models;

namespace Salt.Stars.Web.Services
{
  public class GreetingAPIClient : IGreetingAPIClient
  {
    private IConfiguration _configuration;

    public GreetingAPIClient(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    private string createGreetingUrl(string name)
    {
      var baseUrlForApi = _configuration["ApiBaseUrl"];
      return $"{baseUrlForApi}/greeting?name={name}";
    }

    public async Task<GreetingResponse> getGreeting(string name)
    {
      var client = new HttpClient();
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

      var url = createGreetingUrl(name);
      var greetingTask = client.GetStreamAsync(url);

      var greetingResult = await JsonSerializer.DeserializeAsync<GreetingResponse>(await greetingTask);
      return greetingResult;
    }
  }
}