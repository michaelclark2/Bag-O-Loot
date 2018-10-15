using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BagOLoot
{
    public class MainMenu
    {

        public int Start()
        {
            Console.WriteLine("WELCOME TO THE BAG O' LOOT SYSTEM");
            Console.WriteLine(new string('*', 35));
            Console.WriteLine("1. Register a child");
            Console.WriteLine("2. Assign a toy to a child");
            Console.WriteLine("3. Revoke a toy from child");
            Console.WriteLine("4. Review a child's toy list");
            Console.WriteLine("5. Child toy delivery complete");
            Console.WriteLine("6. Yuletime Delivery Report");
            var option = Console.ReadKey().KeyChar;

            return int.Parse(option.ToString());
        }
    }
}
