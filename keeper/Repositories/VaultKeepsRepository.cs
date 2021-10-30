using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeper.Models;

namespace keeper.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep Post(VaultKeep newData)
    {
      var sql = @"
      INSERT INTO vault_keeps(vaultId, keepId, creatorId)
      VALUES(@VaultId, @KeepId, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }

    internal VaultKeep Get(int id)
    {
      var sql = "SELECT * FROM vault_keeps WHERE id = @id LIMIT 1;";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }

    internal void Delete(int id)
    {
      var sql = "DELETE FROM vault_keeps WHERE id = @id LIMIT 1;";
      var rowsAffected = _db.Execute(sql, new { id });
      if (rowsAffected == 0)
      {
        throw new System.Exception("UHOH delort done didnt delort");
      }
    }

    internal List<VaultKeepViewModel> GetVaultsKeeps(int vaultId)
    {
      var sql = @"
      SELECT
      vk.id as vaultKeepId,
      vk.keepId as keepId,
      k.name as name,
      k.description as description,
      k.img as img,
      k.creatorId as creatorId,
      k.views as views,
      k.shares as shares,
      k.keeps as keeps
      FROM vault_keeps vk
      JOIN keeps k ON k.id = vk.keepId
      WHERE vk.vaultId = @vaultId;
      ";
      return _db.Query<VaultKeepViewModel>(sql, new { vaultId }).ToList();
    }
  }
}