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
        IConfiguration _config;
        List<Child> _children = new List<Child>();

        public ChildrenRegister(IConfiguration config)
        {
            _config = config;
        }

        public int AddChild(string child)
        {
            using (var db = new SqlConnection(_config.GetConnectionString("LootBag")))
            {
                db.Execute($"INSERT INTO Children(Name, Delivered) VALUES ('{child}', 0)");
                int id = db.Query<int>("SELECT Id FROM Children WHERE Id = (SELECT MAX(Id) FROM Children)").First();
                _children.Add(new Child() { Id = id, Name = child, Delivered = false });
                return id;
            }
        }
    }
}
