using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Salt.Stars.Web.Services;
using Salt.Stars.Web.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Salt.Stars.Web.Pages
{
    public class HeroPage : PageModel
    {   
        public string ErrorMessage;
        public HeroResponse HeroResponse;
        private readonly IHeroAPIClient _heroAPIClient;
        public HeroPage(IHeroAPIClient heroAPIClient)
        {
            _heroAPIClient = heroAPIClient;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                HeroResponse = await _heroAPIClient.GetHero(id);
                return Page();
            }
            catch (Exception ErrorMessage)
            {
                return NotFound(ErrorMessage.ToString());
            } 
            
        }
    }
}
