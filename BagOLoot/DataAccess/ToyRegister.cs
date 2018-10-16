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
        DatabaseInterface _db;
        List<Toy> _toys = new List<Toy>();

        public ToyRegister(DatabaseInterface db)
        {
            _db = db;
        }

        public Toy Add(string toyName, Child kid)
        {
            int id = _db.Insert($"INSERT INTO Toys(Name, ChildId) VALUES ('{toyName}', {kid.Id})");

            var toy = new Toy()
            {
                Id = id,
                Name = toyName,
                ChildId = kid.Id
            };

            _toys.Add(toy);

            return toy;
        }

        public IEnumerable<Toy> GetToysForChild(Child kid)
        {
            var toys = new List<Toy>();
            _db.Query($"SELECT * FROM Toys WHERE ChildId = {kid.Id}",
                (SqlDataReader reader) => {
                    while (reader.Read())
                    {
                        toys.Add(new Toy()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader[1].ToString(),
                            ChildId = reader.GetInt32(2)
                        });
                    }
                });
            return toys;
        }

        public void RevokeToy(Toy toy, Child kid)
        {
            _db.Delete($"DELETE FROM Toys WHERE Id = {toy.Id}");
        }
    }
}