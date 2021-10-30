using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keeper.Models;
using keeper.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keeper.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vaultKeepsService;

    public VaultKeepsController(VaultKeepsService vaultKeepsService)
    {
      _vaultKeepsService = vaultKeepsService;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<VaultKeep>> Post([FromBody] VaultKeep newData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newData.CreatorId = userInfo.Id;
        var createdData = _vaultKeepsService.Post(newData);
        createdData.Creator = userInfo;
        if(createdData.CreatorId != userInfo.Id)
        {
          return BadRequest("this is bad");
        }
        return Ok(createdData);

      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<VaultKeep>> Delete(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _vaultKeepsService.Delete(id, userInfo.Id);
        return Ok("VaultKeep has been delortorated.");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}