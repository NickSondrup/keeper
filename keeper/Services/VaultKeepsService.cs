using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vaultKeepsRepository;
    private readonly VaultsRepository _vaultsRepository;
    private readonly KeepsRepository _keepsRepository;

    public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository, VaultsRepository vaultsRepository, KeepsRepository keepsRepository)
    {
      _vaultKeepsRepository = vaultKeepsRepository;
      _vaultsRepository = vaultsRepository;
      _keepsRepository = keepsRepository;
    }

    public VaultKeep Post(VaultKeep newData)
    {
      var foundVault = _vaultsRepository.Get(newData.VaultId);
      var foundKeep = _keepsRepository.Get(newData.KeepId);
      if(foundVault.CreatorId != newData.CreatorId)
      {
        throw new System.Exception("can't add to someone elses vault");
      }
      foundKeep.Keeps++;
      _keepsRepository.AddKeepCount(foundKeep);
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