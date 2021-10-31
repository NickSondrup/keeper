using System;
using System.Collections.Generic;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vaultsRepository;
    private readonly VaultKeepsRepository _vaultKeepsRepository;

    public VaultsService(VaultsRepository vaultsRepository, VaultKeepsRepository vaultKeepsRepository)
    {
      _vaultsRepository = vaultsRepository;
      _vaultKeepsRepository = vaultKeepsRepository;
    }

    public List<Vault> Get()
    {
      return _vaultsRepository.Get();
    }

    internal Vault Get(int vaultId, string userId)
    {
      Vault foundVault = _vaultsRepository.Get(vaultId);
      if(foundVault == null)
      {
        throw new Exception("This thang don't done exist none.");
      }
      if(foundVault.IsPrivate == true && foundVault.CreatorId != userId)
      {
        
        throw new Exception("Can't view someones private vault.");
      }
      return foundVault;
    }
    internal Vault publicGet(int vaultId)
    {
      Vault foundVault =_vaultsRepository.Get(vaultId);
      if(foundVault.IsPrivate == true)
      {
        throw new Exception("Can't view someones private vault.");
      }
      return foundVault;
    }

    internal Vault Post(Vault vaultData)
    {
      return _vaultsRepository.Post(vaultData);
    }

    internal object Edit(Vault vaultData, string userId)
    {
      Vault foundVault = Get(vaultData.Id, userId);
      if(foundVault.CreatorId != userId)
      {
        throw new Exception("Can't edit whats not yours");
      }
      foundVault.Description = vaultData.Description ?? foundVault.Description;
      foundVault.IsPrivate = vaultData.IsPrivate;
      foundVault.Name = vaultData.Name;
      return _vaultsRepository.Edit(foundVault);
    }

    internal List<VaultKeepViewModel> GetVaultsKeeps(int vaultId, string userId)
    {
      if(userId == null)
      {
        var foundVault = publicGet(vaultId);
        if(foundVault.IsPrivate == true)
        {
          throw new Exception("Can't view someones private vault.");
        }
      return _vaultKeepsRepository.GetVaultsKeeps(vaultId);
      }
      var vault = Get(vaultId, userId);
      if(vault.IsPrivate == true)
      {
        throw new Exception("Can't view someones private vault.");
      }
      return _vaultKeepsRepository.GetVaultsKeeps(vaultId);
    }

    internal void Delete(int vaultId, string userId)
    {
      Vault foundVault = Get(vaultId, userId);
      if(foundVault.CreatorId != userId)
      {
        throw new Exception("Can't delete what not yours fool");
      }
      _vaultsRepository.Delete(vaultId);
    }
  }
}