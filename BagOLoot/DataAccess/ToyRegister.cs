using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BagOLoot.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace BagOLoot
{
    public class ToyRegister
    {
        private IConfigurationRoot _configuration;
        private List<Toy> _toys = new List<Toy>();

        public ToyRegister(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public Toy Add(string toyName, Child kid)
        {
            using (var db = new SqlConnection(_configuration.GetConnectionString("LootBag")))
            {
                db.Execute($"INSERT INTO Toys(Name, ChildId) VALUES ('{toyName}', {kid.Id})");
                Toy toy = db.Query<Toy>("SELECT * FROM Toys WHERE Id = (SELECT MAX(Id) FROM Toys)").First();
                _toys.Add(new Toy { Id = toy.Id, Name = toyName, ChildId = kid.Id });
                return toy;

            }
        }
    }
}