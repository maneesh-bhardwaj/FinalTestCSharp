using System;

namespace FinalExamCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomCollection<int> IntList = new CustomCollection<int>();

            IntList.AddItem(5);
            IntList.AddItem(8);
            IntList.AddItem(10);
            IntList.AddItem(2);

            Console.WriteLine("Before Sorting");
            IntList.DisplayCollection();

            Console.WriteLine("Display 3rd item in collection");
            Console.WriteLine(IntList.GetItem(3));

            var sortedList = IntList.ReturnSortedCollection();
            Console.WriteLine("Sorted Collection");
            foreach (var item in sortedList)
            {
                Console.WriteLine(item);
            }


        }
    }
}
