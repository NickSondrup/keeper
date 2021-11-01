using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vaultKeepsRepository;
    private readonly VaultsRepository _vaultsRepository;

    public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository, VaultsRepository vaultsRepository)
    {
      _vaultKeepsRepository = vaultKeepsRepository;
      _vaultsRepository = vaultsRepository;
    }

    public VaultKeep Post(VaultKeep newData)
    {
      var foundVault = _vaultsRepository.Get(newData.VaultId);
      if(foundVault.CreatorId != newData.CreatorId)
      {
        throw new System.Exception("can't add to someone elses vault");
      }
      return _vaultKeepsRepository.Post(newData);
    }

    internal void Delete(int id, string userId)
    {
      VaultKeep foundItem = Get(id);
      if(foundItem.CreatorId != userId)
      {
        throw new System.Exception("can't delort what aint yours");
      }
      _vaultKeepsRepository.Delete(id);
    }

    private VaultKeep Get(int id)
    {
      return _vaultKeepsRepository.Get(id);
    }
  }
}