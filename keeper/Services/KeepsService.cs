using System;
using System.Collections.Generic;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _keepsRepository;

    public KeepsService(KeepsRepository keepsRepository)
    {
      _keepsRepository = keepsRepository;
    }

    public List<Keep> Get()
    {
      return _keepsRepository.Get();
    }

    public Keep Get(int keepId)
    {
      var foundKeep = _keepsRepository.Get(keepId);
      if(foundKeep == null)
      {
        throw new Exception("This thang don't exist.");
      }
      return foundKeep;
    }
    public Keep Post(Keep newKeep)
    {
      return _keepsRepository.Post(newKeep);
    }

    public Keep Edit(Keep keepData)
    {
      Keep foundKeep = Get(keepData.Id);
      if (foundKeep.CreatorId != keepData.CreatorId)
      {
        throw new Exception("THE DARK FIRE WILL NOT AVAIL YOU FLAME OF UDUN!");
      }
      foundKeep.Description = keepData.Description ?? foundKeep.Description;
      foundKeep.Img = keepData.Img ?? foundKeep.Img;
      foundKeep.Keeps = keepData.Keeps;
      foundKeep.Name = keepData.Name ?? foundKeep.Name;
      foundKeep.Shares = keepData.Shares;
      foundKeep.Views = keepData.Views;
      return _keepsRepository.Edit(foundKeep);
    }

    public void Delete(int keepId, string userId)
    {
      Keep foundKeep = Get(keepId);
      if(foundKeep.CreatorId != userId)
      {
        throw new Exception("THE DARK FIRE WILL NOT AVAIL YOU FLAME OF UDUN!");
      }
      _keepsRepository.Delete(keepId);
    }
  }
}