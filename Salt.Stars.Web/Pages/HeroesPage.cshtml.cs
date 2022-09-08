using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Salt.Stars.Web.Services;
using Salt.Stars.Web.Models;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Salt.Stars.Web.Pages
{
    
    public class HeroesPage : PageModel
    {
        public string ErrorMessage;
        public HeroListResponse HeroesResponse;
        private readonly IHeroAPIClient _heroAPIClient;
        public HeroesPage(IHeroAPIClient heroAPIClient)
        {
            _heroAPIClient = heroAPIClient;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                HeroesResponse = await _heroAPIClient.GetHeroes();
                return Page();
            }
            catch (System.Exception ErrorMessage)
            {
                return NotFound(ErrorMessage.ToString());
            }

        }
    }

}
