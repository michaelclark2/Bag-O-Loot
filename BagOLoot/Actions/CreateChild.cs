using System;
using System.Collections.Generic;
using System.Text;
using BagOLoot.DataAccess;

namespace BagOLoot.Actions
{
    public class CreateChild
    {
		public static void Action(ChildrenRegister registry)
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the child");
            Console.Write("> ");
            string childName = Console.ReadLine();
            int id = registry.AddChild(childName);
            Console.WriteLine(id);
            
        }
    }
}
