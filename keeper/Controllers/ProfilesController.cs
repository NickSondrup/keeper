using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keeper.Models;
using keeper.Services;
using Microsoft.AspNetCore.Mvc;

namespace keeper.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _profilesService;
    private readonly AccountService _accountService;

    public ProfilesController(ProfilesService profilesService, AccountService accountService)
    {
      _profilesService = profilesService;
      _accountService = accountService;
    }

    [HttpGet("{profileId}")]
    public ActionResult<Profile> Get(string profileId)
    {
      try
      {
        Profile profile = _profilesService.Get(profileId);
        return Ok(profile);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{profileId}/keeps")]
    public ActionResult<List<Keep>> GetProfileKeeps(string profileId)
    {
      try
      {
        var keeps = _profilesService.GetProfileKeeps(profileId);
        return Ok(keeps);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{profileId}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetProfileVaults(string profileId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        var vaults = _profilesService.GetProfileVaults(profileId, userInfo?.Id);
        return Ok(vaults);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpPut("{profileId}")]
    public async Task<ActionResult<Account>> EditProfile(string profileId, [FromBody] Account newData)
    {
      try
      {
           Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
           var email = userInfo.Email;
           var profile = _accountService.Edit(newData, email);
           return Ok(profile);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
  } 
}