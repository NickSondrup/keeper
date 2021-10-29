using System.Collections.Generic;
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
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vaultsService;

    public VaultsController(VaultsService vaultsService)
    {
      _vaultsService = vaultsService;
    }

    [HttpGet]
    public ActionResult<List<Vault>> Get()
    {
      try
      {
        var vaults = _vaultsService.Get();
        return vaults;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{vaultId}")]
    public ActionResult<Vault> Get(int vaultId)
    {
      try
      {
       Vault vault = _vaultsService.Get(vaultId);
       return vault;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public async  Task<ActionResult<Vault>> Post([FromBody] Vault vaultData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        vaultData.CreatorId = userInfo.Id;
        Vault createdVault = _vaultsService.Post(vaultData);
        createdVault.Creator = userInfo;
        return Ok(createdVault);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}