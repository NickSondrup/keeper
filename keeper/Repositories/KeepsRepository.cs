using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeper.Models;

namespace keeper.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Keep> Get()
    {
      var sql = @"
      SELECT
      k.*,
      a.*
      FROM keeps k
      JOIN accounts a ON a.id = k.creatorId
      ";
      return _db.Query<Keep, Profile, Keep>(sql, (k, a) =>
      {
        k.Creator = a;
        return k;
      }).ToList();
    }

    internal Keep Get(int keepId)
    {
      var sql = @"
      SELECT
      k.*,
      a.*
      FROM keeps k
      JOIN accounts a ON a.id = k.creatorId
      WHERE k.id = @keepId;
      ";
      return _db.Query<Keep, Profile, Keep>(sql, (k, a) =>
      {
        k.Creator = a;
        return k;
      }, new{keepId}).FirstOrDefault();
    }


    internal Keep Post(Keep newKeep)
    {
      var sql = @"
      INSERT INTO keeps (name, description, img, views, shares, keeps, creatorId)
      VALUES(@Name, @Description, @Img, @Views, @Shares, @Keeps, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    internal void AddKeepCount(Keep foundKeep)
    {
      string sql = @"
      UPDATE keeps
      SET
      keeps = @Keeps
      WHERE id = @Id; 
      ";
      var rowsAffected = _db.Execute(sql, foundKeep);
      if(rowsAffected == 0)
      {
        throw new Exception("update failed");
      }
    }

    internal void AddView(Keep foundKeep)
    {
       string sql = @"
      UPDATE keeps
      SET
      views = @Views
      WHERE id = @Id;
      ";
      var rowsAffected = _db.Execute(sql, foundKeep);
      if(rowsAffected == 0)
      {
        throw new Exception("Update failed");
      }
    }

    internal Keep Edit(Keep foundKeep)
    {
      string sql = @"
      UPDATE keeps
      SET
      name = @Name,
      description = @Description,
      img = @Img,
      views = @Views,
      shares = @Shares,
      keeps = @Keeps
      WHERE id = @Id;
      ";
      var rowsAffected = _db.Execute(sql, foundKeep);
      if(rowsAffected == 0)
      {
        throw new Exception("Update failed");
      }
      return foundKeep;
    }

    internal void Delete(int keepId)
    {
      var sql = @"
      DELETE FROM keeps
      WHERE id = @keepId
      LIMIT 1;
      ";
      var rowsAffected = _db.Execute(sql, new{ keepId });
      if(rowsAffected == 0)
      {
        throw new Exception("Delete Keep failed! and pretty badly too.");
      }
    }
  }
}