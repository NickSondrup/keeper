using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeper.Models;

namespace keeper.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Profile Get(string profileId)
    {
      var sql = "SELECT * FROM accounts WHERE id = @profileId;";
      return _db.QueryFirstOrDefault<Profile>(sql, new{ profileId });
    }

    internal List<Keep> GetProfileKeeps(string profileId)
    {
      var sql ="SELECT * FROM keeps WHERE creatorId = @profileId;";
      return _db.Query<Keep>(sql, new{ profileId }).ToList();
    }

    internal List<Vault> GetProfileVaults(string profileId)
    {
      var sql ="SELECT * FROM vaults WHERE creatorId = @profileId AND isPrivate = 0;";
      return _db.Query<Vault>(sql, new{ profileId }).ToList();
    }

    internal List<Vault> GetUsersVaults(string profileId)
    {
       var sql ="SELECT * FROM vaults WHERE creatorId = @profileId;";
      return _db.Query<Vault>(sql, new{ profileId }).ToList();
    }
  }
}