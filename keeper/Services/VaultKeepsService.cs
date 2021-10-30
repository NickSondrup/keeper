using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vaultKeepsRepository;

    public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository)
    {
      _vaultKeepsRepository = vaultKeepsRepository;
    }

    public VaultKeep Post(VaultKeep newData)
    {
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