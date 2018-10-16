using System;
using BagOLoot.DataAccess;

namespace BagOLoot.Actions
{
    public class ShowBag
    {
        public static void Action(ToyRegister bag, ChildrenRegister book)
        {
            Console.Clear();
            Console.WriteLine("Show bag of loot for which child?");

            var children = book.GetChildren();
            foreach (var child in children)
            {
                Console.WriteLine($"{child.Id}: {child.Name}");
            }
            Console.Write("> ");

            var childId = int.Parse(Console.ReadLine());

            var kid = book.GetChild(childId);

            var toys = bag.GetToysForChild(kid);

            Console.Clear();
            Console.WriteLine($"{kid.Name}'s Bag o' loot");
            Console.WriteLine(new string('-', 30));
            foreach(var toy in toys)
            {
                Console.WriteLine($"{toy.Name}");
            }
            Console.ReadLine();
        }
    }
}