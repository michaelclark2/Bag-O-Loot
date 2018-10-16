using System;
using BagOLoot.DataAccess;

namespace BagOLoot.Actions
{
    public class DeliverToys
    {
        public static void Action(ChildrenRegister book)
        {
            Console.Clear();
            Console.WriteLine("Deliver toys to which child?");
            var children = book.GetChildren();
            foreach (var child in children)
            {
                Console.WriteLine($"{child.Id}: {child.Name}");
            }
            Console.Write("> ");
            int childId = int.Parse(Console.ReadLine());

            var kid = book.GetChild(childId);

            book.DeliverToChild(kid);
        }
    }
}