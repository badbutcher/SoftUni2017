namespace Collection_Hierarchy
{
    using Interfaces;
    using System;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            IAddCollection<string> addColletion = new AddCollection<string>();
            IAddRemoveCollection<string> addRemCollection = new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();

            string[] itemsToAdd = Console.ReadLine().Split(' ');
            int removeOperationsCount = int.Parse(Console.ReadLine());

            StringBuilder addCollAddIndexes = new StringBuilder();
            StringBuilder addRemCollAddIndexes = new StringBuilder();
            StringBuilder myListCollAddIndexes = new StringBuilder();

            foreach (var item in itemsToAdd)
            {
                addCollAddIndexes.Append($"{addColletion.Add(item)} ");
                addRemCollAddIndexes.Append($"{addRemCollection.Add(item)} ");
                myListCollAddIndexes.Append($"{myList.Add(item)} ");
            }

            StringBuilder addRemCollRemoveElements = new StringBuilder();
            StringBuilder myListRemoveElements = new StringBuilder();

            for (int i = 0; i < removeOperationsCount; i++)
            {
                addRemCollRemoveElements.Append($"{addRemCollection.Remove()} ");
                myListRemoveElements.Append($"{myList.Remove()} ");
            }

            Console.WriteLine(addCollAddIndexes.ToString().Trim());
            Console.WriteLine(addRemCollAddIndexes.ToString().Trim());
            Console.WriteLine(myListCollAddIndexes.ToString().Trim());

            Console.WriteLine(addRemCollRemoveElements.ToString().Trim());
            Console.WriteLine(myListRemoveElements.ToString().Trim());
        }
    }
}