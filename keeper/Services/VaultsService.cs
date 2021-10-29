using System;
using System.Collections.Generic;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vaultsRepository;

    public VaultsService(VaultsRepository vaultsRepository)
    {
      _vaultsRepository = vaultsRepository;
    }

    public List<Vault> Get()
    {
      return _vaultsRepository.Get();
    }

    internal Vault Get(int vaultId)
    {
      Vault foundVault = _vaultsRepository.Get(vaultId);
      if(foundVault == null)
      {
        throw new Exception("This thang don't done exist none.");
      }
      return foundVault;
    }

    internal Vault Post(Vault vaultData)
    {
      return _vaultsRepository.Post(vaultData);
    }
  }
}