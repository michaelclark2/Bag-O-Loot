using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using BagOLoot.DataAccess;
using BagOLoot.Actions;

namespace BagOLoot
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new DatabaseInterface("LootBag");

            var BagOLoot = new MainMenu();
            var book = new ChildrenRegister(db);
            var bag = new ToyRegister(db);

            int choice;

            do
            {
                choice = BagOLoot.Start();

                switch (choice)
                {
                    case 1:
                        CreateChild.Action(book);
                        break;
                    case 2:
                        AddToy.Action(bag, book);
                        break;
                    case 3:
                        RevokeToy.Action(bag, book);
                        break;
                }
            } while (choice != 7);
        }
    }
}
