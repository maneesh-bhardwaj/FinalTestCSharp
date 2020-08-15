using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace FinalExamCSharp
{
    public class CustomCollection<T> where T:struct
    {
        private Collection<T> CollectionList = new Collection<T>();

        public void AddItem(T item)
        {
            CollectionList.Add(item);
        }
        public T GetItem(int index)
        {
            if(index < CollectionList.Count)
                return CollectionList[index-1];
            else
            {
                Console.WriteLine("Invalid Index");
                return default;
            }               
        }
        public List<T> ReturnSortedCollection()
        {
            var SortedList = CollectionList.OrderByDescending(i => i);
            return SortedList.ToList();
        }
        public void DisplayCollection()
        {
            foreach (var item in CollectionList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
