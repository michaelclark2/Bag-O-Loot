using System;
using System.Linq;
using BagOLoot.DataAccess;

namespace BagOLoot.Actions
{
    public class RevokeToy
    {
        public static void Action(ToyRegister bag, ChildrenRegister book)
        {
            Console.Clear();
            Console.WriteLine("Choose a child");

            var children = book.GetChildren();
            foreach(var child in children)
            {
                Console.WriteLine($"{child.Id}: {child.Name}");
            }

            int childId = int.Parse(Console.ReadLine());

            var kid = book.GetChild(childId);

            Console.WriteLine($"Choose a toy to revoke from {kid.Name}");
            Console.Write("> ");
            var kidsToys = bag.GetToysForChild(kid);
            foreach(var toy in kidsToys)
            {
                Console.WriteLine($"{toy.Id}: {toy.Name}");
            }

            int toyId = int.Parse(Console.ReadLine());
            var toyToRevoke = kidsToys.First(t => t.Id == toyId);

            bag.RevokeToy(toyToRevoke, kid);
            
        }
    }
}