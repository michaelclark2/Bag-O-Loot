using BagOLoot.DataAccess;
using System;
using System.Linq;

namespace BagOLoot
{
    public class AddToy
    {
        public static void Action(ToyRegister toyRegister, ChildrenRegister childRegister)
        {
            Console.Clear();
            Console.WriteLine("Choose a child");

            var children = childRegister.GetChildren();

            foreach(var child in children)
            {
                Console.WriteLine($"{child.Id}: {child.Name}");
            }

            Console.Write("> ");
            int childId = int.Parse(Console.ReadLine());

            var kid = childRegister.GetChild(childId);

            Console.WriteLine("Enter a toy");
            Console.Write("> ");
            string toyName = Console.ReadLine();
            toyRegister.Add(toyName, kid);


        }
    }
}