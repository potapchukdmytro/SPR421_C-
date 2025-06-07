using System.Collections;

namespace _08_Collections
{
    class Square : IComparable
    {
        public float Width { get; set; }

        public int CompareTo(object? obj)
        {
            // -1 лівий елемент менший
            // 1 правий елемент менший
            // 0 однакові

            if(obj == null || !(obj is Square))
            {
                return -1;
            }

            var other = (Square)obj;

            if (Width < other.Width)
            {
                return -1;
            }
            else if (Width > other.Width)
            {
                return 1;
            }
            else
            {
                return 0;
            }

            //return Width.CompareTo(other.Width);
        }

        public override string ToString()
        {
            return $"Width: {Width}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Non Generic


            // Stack
            //Stack stack = new Stack();
            //stack.Push(5);
            //stack.Push("Value");
            //stack.Push(true);
            //stack.Push(5.6f);
            //stack.Push(DateTime.Now);

            //while(stack.Count > 0)
            //{
            //    Console.WriteLine(stack.Pop());
            //}

            // Queue
            //Console.WriteLine("======= Queue ======");

            //Queue queue = new Queue();
            //queue.Enqueue("2025");
            //queue.Enqueue(false);
            //queue.Enqueue(100);
            //queue.Enqueue(3.14);

            //while(queue.Count > 0)
            //{
            //    Console.WriteLine(queue.Dequeue());
            //}


            // ArrayList
            //Console.WriteLine("======= ArrayList ======");
            //ArrayList array = new ArrayList();
            //array.Add(6);
            //array.Add(new Thread(() => { }));
            //int[] arr = [1, 2, 3, 4, 5];
            //array.AddRange(arr);

            //foreach (var item in array)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("Count: " + array.Count);
            //Console.WriteLine("Capacity: " + array.Capacity);

            //array.TrimToSize(); // прирівнює Capacity до Count





            // Generic
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();



            // List
            //List<string> months = new List<string>();
            //months.Add("January");
            //months.Add("February");
            //string[] newMonths = ["March", "April"];
            //months.AddRange(newMonths);

            //months[3] = "June";
            //months.Insert(0, "December");

            //foreach (var month in months)
            //{
            //    Console.WriteLine(month);
            //}

            //months.Remove("December");

            //Console.WriteLine("======= =======");

            //foreach (var month in months)
            //{
            //    Console.WriteLine(month);
            //}

            //Console.WriteLine("======= =======");

            //months.Sort();

            //foreach (var month in months)
            //{
            //    Console.WriteLine(month);
            //}


            // Ініціалізація під час оголошення
            //List<Square> squares = new List<Square>
            //{
            //    new Square{ Width = 10},
            //    new Square{ Width = 15},
            //    new Square{ Width = 2},
            //    new Square{ Width = 12},
            //    new Square{ Width = 23}
            //};

            //squares.Sort();

            //foreach (var square in squares)
            //{
            //    Console.WriteLine(square);
            //}

            //squares.ForEach((sqr) => Console.WriteLine("Area: " + sqr.Width * sqr.Width));
            //squares.RemoveAll((sqr) => sqr.Width >= 15);

            //foreach (var square in squares)
            //{
            //    Console.WriteLine(square);
            //}




            // Dictionary
            //var weekDays = new Dictionary<int, string>();

            //weekDays.Add(1, "Monday");
            //weekDays.Add(2, "Tuesday");
            //weekDays.Add(3, "Wednesday");
            //weekDays.Add(4, "Thursday");
            //weekDays.Add(5, "Friday");

            //foreach (var day in weekDays)
            //{
            //    Console.WriteLine($"{day.Key}: {day.Value}");
            //}

            //foreach (var value in weekDays.Values)
            //{
            //    Console.WriteLine(value);
            //}

            //foreach (var key in weekDays.Keys)
            //{
            //    Console.WriteLine(key);
            //}

            //if(!weekDays.ContainsKey(1))
            //{
            //    weekDays.Add(1, "test");
            //}





            //var uk_en = new Dictionary<string, List<string>>();
            //uk_en.Add("шапка", ["cap", "hat"]);
            //uk_en.Add("палиця", ["stick", "staff"]);

            //string userWord = "монітор";

            //if(uk_en.ContainsKey(userWord))
            //{
            //    var translate = uk_en[userWord];

            //    foreach (var item in translate)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Word not found");
            //}





            // LinkedList
            LinkedList<int> ints = new LinkedList<int>();

            ints.AddLast(1);
            ints.AddLast(2);
            ints.AddLast(3);

            var node = ints.Find(2);

            ints.AddAfter(node, 5);

            foreach (var i in ints)
            {
                Console.WriteLine(i);
            }
        }
    }
}
