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
    public class KeepsController : ControllerBase
    {
      private readonly KeepsService _keepsService;

    public KeepsController(KeepsService keepsService)
    {
      _keepsService = keepsService;
    }

    [HttpGet]
    public ActionResult<List<Keep>> Get()
    {
      try
      {
        var keeps = _keepsService.Get();
        return keeps;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{keepId}")]
    public ActionResult<Keep> Get(int keepId)
    {
      try
      {
        var keep = _keepsService.Get(keepId);
        return Ok(keep);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Keep>> Post([FromBody] Keep newKeep)
    {
      try
      {
        var userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newKeep.CreatorId = userInfo.Id;
        Keep createdKeep = _keepsService.Post(newKeep);
        createdKeep.Creator = userInfo;
        return Ok(createdKeep);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPut("{keepId}")]
    public async Task<ActionResult<Keep>> Edit([FromBody] Keep keepData, int keepId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        keepData.CreatorId = userInfo.Id;
        keepData.Id = keepId;
        return Ok(_keepsService.Edit(keepData));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{keepId}")]
    public async Task<ActionResult> Delete(int keepId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _keepsService.Delete(keepId, userInfo.Id);
        return Ok("Keep was deleted and destroyed");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}