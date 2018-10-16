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

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var BagOLoot = new MainMenu();
            var book = new ChildrenRegister(configuration);
            var bag = new ToyRegister(configuration);

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
                }
            } while (choice != 7);
        }
    }
}
