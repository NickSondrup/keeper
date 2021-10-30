using System.Collections.Generic;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _profilesRepository;

    public ProfilesService(ProfilesRepository profilesRepository)
    {
      _profilesRepository = profilesRepository;
    }

    internal Profile Get(string profileId)
    {
      return _profilesRepository.Get(profileId);
    }

    internal List<Keep> GetProfileKeeps(string profileId)
    {
      return _profilesRepository.GetProfileKeeps(profileId);
    }

    internal List<Vault> GetProfileVaults(string profileId, string userId)
    {
      if(profileId == userId)
      {
        return _profilesRepository.GetUsersVaults(profileId);
      }
      return _profilesRepository.GetProfileVaults(profileId);
    }
  }
}