using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BagOLoot
{
    public class BagOLoot
    {
        IConfiguration _config;
        public BagOLoot(IConfiguration config)
        {
            _config = config;
        }

        public void Start()
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

            switch (int.Parse(option.ToString()))
            {
                case 1:
                    Console.WriteLine("option 1");
                    break;
                case 2:
                    Console.WriteLine("option 2");
                    break;
                case 3:
                    Console.WriteLine("option 3");
                    break;
                case 4:
                    Console.WriteLine("option 4");
                    break;
                case 5:
                    Console.WriteLine("option 5");
                    break;
                case 6:
                    Console.WriteLine("option 6");
                    break;
            }

            Console.ReadLine();
        }
    }
}
