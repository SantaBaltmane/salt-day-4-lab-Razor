using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Salt.Stars.Web.Models;
using Salt.Stars.Web.Services;

namespace Salt.Stars.Web.Pages
{
  public class IndexPage : PageModel
  {
    private readonly IGreetingAPIClient _greetingAPIClient;
    public IndexPage(IGreetingAPIClient greetingAPIClient) => _greetingAPIClient = greetingAPIClient;

    [BindProperty]
    public GreetingResponse Greeting { get; set; }

    [BindProperty]
    public string ErrorMessage { get; set; }

    [BindProperty(SupportsGet = true)]
    public string DeveloperName { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
      try
      {
        if (!string.IsNullOrEmpty(DeveloperName))
        {
          Greeting = await _greetingAPIClient.getGreeting(DeveloperName);
        }
      }
      catch (System.Exception ex)
      {
        ErrorMessage = $"Something went terrible wrong ({ex.Message})";
      }

      return Page();
    }
  }
}
