using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeper.Models;

namespace keeper.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Vault> Get()
    {
      var sql = @"
      SELECT
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (v, a) =>
      {
        v.Creator = a;
        return v;
      }).ToList();

    }

    internal Vault Get(int vaultId)
    {
     var sql = @"
      SELECT
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.id = @vaultId
      ";
      return _db.Query<Vault, Profile, Vault>(sql, (v, a) =>
      {
        v.Creator = a;
        return v;
      }, new{ vaultId }).FirstOrDefault();
    }

    internal Vault Post(Vault vaultData)
    {
     var sql = @"
     INSERT INTO vaults (name, description, isPrivate, coverImg, creatorId)
     VALUES(@Name, @Description, @IsPrivate, @CoverImg, @CreatorId);
     SELECT LAST_INSERT_ID();
     ";
     var id = _db.ExecuteScalar<int>(sql, vaultData);
     vaultData.Id = id;
     return vaultData;
    }

    internal object Edit(Vault foundVault)
    {
      string sql = @"
      UPDATE vaults
      SET
      name = @Name,
      description = @Description,
      isPrivate = @IsPrivate,
      coverImg = @CoverImg
      WHERE id = @Id LIMIT 1;
      ";
      var rowsAffected = _db.Execute(sql, foundVault);
      if (rowsAffected == 0)
      {
        throw new Exception("Update failed I guess");
      }
      return foundVault;
    }

    internal void Delete(int vaultId)
    {
      var sql = "DELETE FROM vaults WHERE id = @vaultId LIMIT 1;";
      var rowsAffected = _db.Execute(sql, new{ vaultId });
      if(rowsAffected == 0)
      {
        throw new Exception("Delete failed for some reason");
      }
    }
  }
}