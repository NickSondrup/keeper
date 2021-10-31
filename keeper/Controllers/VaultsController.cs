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
    public async  Task<ActionResult<Vault>> Get(int vaultId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        if(userInfo == null)
        {
          Vault pVault = _vaultsService.publicGet(vaultId);
          return pVault;
        }
        Vault vault = _vaultsService.Get(vaultId, userInfo.Id);
        return vault;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{vaultId}/keeps")]
    public async Task<ActionResult<List<VaultKeepViewModel>>> GetVaultsKeeps(int vaultId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        var foundVault = Get(vaultId);
        List<VaultKeepViewModel> keeps = _vaultsService.GetVaultsKeeps(vaultId, userInfo?.Id);
        return Ok(keeps);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Vault>> Post([FromBody] Vault vaultData)
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

    [Authorize]
    [HttpPut("{vaultId}")]
    public async Task<ActionResult<Vault>> Put([FromBody] Vault vaultData, int vaultId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        vaultData.CreatorId = userInfo.Id;
        vaultData.Id = vaultId;
        return Ok(_vaultsService.Edit(vaultData, userInfo.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{vaultId}")]
    public async Task<ActionResult> Delete(int vaultId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _vaultsService.Delete(vaultId, userInfo.Id);
        return Ok("the vault was deleted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}