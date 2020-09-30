using System;

namespace MyList
{
    class Program
    {

        static void Main(string[] args)
        {
            MyStackList<string> shoppingList = new MyStackList<string>();
            MyStackList<string> removeList = new MyStackList<string>();
            shoppingList.Push("Bread");
            shoppingList.Push("Butter");
            shoppingList.Push("Tea");
            shoppingList.Push("Coffee");
            shoppingList.Push("Sugar");

            foreach (var item in shoppingList)
            {
                Console.WriteLine(item);
            }
            shoppingList.AddToRemoveList += removeList.Push;


            shoppingList.Pop();
            shoppingList.Pop();


            Console.WriteLine();

            foreach (var item in removeList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var filteredList = MyStackList<string>.filter(shoppingList, shoppingList.filterHandler);

            foreach (var item in filteredList)
            {
                Console.WriteLine(item);
            }

        }

    }
}
