using System;

namespace MyList
{
    class Program
    {
        

        static void Main(string[] args)
        {
            MyStackList<string> shoppingList = new MyStackList<string>();

            shoppingList.Push("Bread");
            shoppingList.Push("Butter");
            shoppingList.Push("Tea");
            shoppingList.Push("Coffee");
            shoppingList.Push("Sugar");

            foreach (var item in shoppingList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
