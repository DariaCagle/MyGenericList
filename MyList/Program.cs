using System;

namespace MyList
{
    class Program
    {
        public delegate bool FilterHandler(string s);

        public static bool TrueFunc(string s)
        {
            return true;
        }

        static void Main(string[] args)
        {
            MyStackList<string> shoppingList = new MyStackList<string>();

            MyStackList<string> expelled = new MyStackList<string>();

            FilterHandler filterHandler = new FilterHandler(TrueFunc);

            Filter(filterHandler, "Bread", shoppingList, expelled);
            Filter(filterHandler, "Butter", shoppingList, expelled);
            Filter(filterHandler, "Tea", shoppingList, expelled);
            Filter(filterHandler, "Coffee", shoppingList, expelled);
            Filter(filterHandler, "Sugar", shoppingList, expelled);

            foreach (var item in shoppingList)
            {
                Console.WriteLine(item);
            }
        }

        public static void Filter(FilterHandler filterHandler, string s, MyStackList<string> shoppingList, MyStackList<string> expelled)
        {
            if (filterHandler(s))
            {
                shoppingList.Push(s);
            }
            else
            {
                expelled.Push(s);
            }
        }
    }
}
