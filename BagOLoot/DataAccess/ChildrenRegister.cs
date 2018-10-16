using BagOLoot.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BagOLoot.DataAccess
{
    public class ChildrenRegister
    {
        DatabaseInterface _db;
        List<Child> _children = new List<Child>();

        public ChildrenRegister(DatabaseInterface db)
        {
            _db = db;
        }

        public int AddChild(string child)
        {
            return _db.Insert($"INSERT INTO Children(Name, Delivered) VALUES ('{child}', 0)");
        }

        public void DeliverToChild(Child kid)
        {
            _db.Delete($"UPDATE Children SET Delivered = 1 WHERE Id = {kid.Id}");
        }

        public IEnumerable<Child> GetChildren()
        {

            _db.Query("SELECT * FROM Children",
                (SqlDataReader reader) =>
                {
                    _children.Clear();
                    while (reader.Read())
                    {
                        _children.Add(new Child()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader[1].ToString(),
                            Delivered = reader.GetInt32(0) == 1
                        });
                    }
                });

            return _children;
        }
        public Child GetChild(int id) => _children.SingleOrDefault(c => c.Id == id);
    }
}
