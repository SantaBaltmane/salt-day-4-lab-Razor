using System.Threading.Tasks;
using Salt.Stars.Web.Models;

namespace Salt.Stars.Web.Services
{
  public interface IGreetingAPIClient
  {
    Task<GreetingResponse> getGreeting(string name);
  }
}
