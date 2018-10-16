using System;
using System.Linq;
using BagOLoot.DataAccess;

namespace BagOLoot.Actions
{
    public class YuletimeReport
    {
        public static void Action(ToyRegister bag, ChildrenRegister book)
        {
            Console.Clear();
            Console.WriteLine("YULETIME DELIVERY REPORT");
            Console.WriteLine(new string('%', 30));
            var childrenDelivered = book.GetChildren();
            childrenDelivered = childrenDelivered.Where(c => c.Delivered);

            foreach (var child in childrenDelivered)
            {
                Console.WriteLine($"{child.Name}");
                var toys = bag.GetToysForChild(child);
                foreach(var toy in toys)
                {
                    Console.WriteLine("  " + $"{toy.Name}");
                }
                Console.WriteLine();
            }
            


            Console.ReadLine();
        }
    }
}