using System.Collections;

namespace _08_Collections_2
{
    internal class Program
    {
        static void PrintCollection(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            // LinkedList

            //LinkedList<string> colors = new LinkedList<string>();

            //colors.AddLast("red");
            //colors.AddFirst("green");

            //LinkedListNode<string> node = new LinkedListNode<string>("blue");
            //colors.AddLast(node);

            //var redNode = colors.Find("red");

            //if(redNode != null)
            //{
            //    colors.AddAfter(redNode, "yellow");
            //}

            //PrintCollection(colors);



            // HashSet
            HashSet<int> ints = new HashSet<int>();
            ints.Add(1);
            ints.Add(6);
            ints.Add(10);
            ints.Add(6);
            ints.Add(5);
            ints.Add(1);
            ints.Add(10);
            ints.Add(2);
            ints.Add(9);

            PrintCollection(ints);
        }
    }
}
