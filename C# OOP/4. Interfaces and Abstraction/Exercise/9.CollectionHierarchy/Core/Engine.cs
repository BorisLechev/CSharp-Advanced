using _9.CollectionHierarchy.Collections;
using _9.CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _9.CollectionHierarchy.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] stringsToAdd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int numberOfRemoveOperations = int.Parse(Console.ReadLine());

            int[] addCollectionAddingElements = GetAddingResult(stringsToAdd, addCollection);
            Console.WriteLine(string.Join(" ", addCollectionAddingElements));

            int[] addRemoveElementsCollection = GetAddingResult(stringsToAdd, addRemoveCollection);
            Console.WriteLine(string.Join(" ", addRemoveElementsCollection));

            int[] myListAddElements = GetAddingResult(stringsToAdd, myList);
            Console.WriteLine(string.Join(" ", myListAddElements));

            string[] addRemoveElementsRemovingElements = 
                GetRemovingResult(numberOfRemoveOperations, addRemoveCollection);
            Console.WriteLine(string.Join(" ", addRemoveElementsRemovingElements));

            string[] myListRemovingResult = GetRemovingResult(numberOfRemoveOperations, myList);
            Console.WriteLine(string.Join(" ", myListRemovingResult));
        }

        private string[] GetRemovingResult(int numberOfRemoveOperations, IAddableAndRemovable addRemoveCollection)
        {
            string[] result = new string[numberOfRemoveOperations];

            for (int i = 0; i < numberOfRemoveOperations; i++)
            {
                result[i] = addRemoveCollection.Remove();
            }

            return result;
        }

        private int[] GetAddingResult(string[] stringsToAdd, IAddable addCollection)
        {
            int[] result = new int[stringsToAdd.Length];

            for (int i = 0; i < stringsToAdd.Length; i++)
            {
                result[i] = addCollection.Add(stringsToAdd[i]);
            }

            return result;
        }
    }
}
