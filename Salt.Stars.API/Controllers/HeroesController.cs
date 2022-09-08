using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Salt.Stars.API.Models;

namespace Salt.Stars.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public partial class HeroesController : ControllerBase
  {
    private readonly ISwApiClient _swApiClient;

    public HeroesController(ISwApiClient swApiClient)
    {
      _swApiClient = swApiClient;
    }

    [HttpGet]
    public async Task<ActionResult<HeroListResponse>> GetHeroListAsync()
    {
      try
      {
        var heroListResponse = await _swApiClient.getHerosFromSwapi();
        heroListResponse.PageSize = heroListResponse.Heroes.Count;
        heroListResponse.CurrentPage = 1;
        heroListResponse.RequestedAt = DateTime.Now;

        return heroListResponse;

      }
      catch (System.Exception ex)
      {
        return NotFound(ex.ToString());
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HeroResponse>> GetHeroAsync(short id)
    {
      try
      {
        var hero = await _swApiClient.getHeroFromSwapi(id);

        return new HeroResponse
        {
          Hero = hero,
          RequestedAt = DateTime.Now
        };
      }
      catch (System.Exception ex)
      {
        return NotFound(ex.ToString());
      }
    }

  }
}
