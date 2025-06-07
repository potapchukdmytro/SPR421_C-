using System.Collections;

namespace _08_Generic
{
    interface ISum
    {
        object Sum(object b);
    }

    public class Number : ISum
    {
        public int Value { get; set; }

        public object Sum(object b)
        {
            if(b is Number)
            {
                var number = new Number();
                number.Value = Value + ((Number)b).Value;
                return number;
            }
            else
            {
                return new Number { Value = Value };
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class VectorEnumerator<T> : IEnumerator
    {
        private T[] data;
        private int index;

        public VectorEnumerator(T[] data)
        {
            this.data = data;
            index = -1;
        }

        public object? Current => data[index];

        public bool MoveNext()
        {
            index++;
            return index >= data.Length ? false : true;
        }

        public void Reset()
        {
            index = -1;
        }
    }

    public class Vector<T> : IEnumerable
    {
        private T[] data;

        public Vector()
        {
            data = [];
        }

        public int Length { get =>  data.Length; }

        public void Add(T value)
        {
            T[] tmp = new T[Length + 1];

            for (int i = 0; i < Length; i++)
            {
                tmp[i] = data[i];
            }

            tmp[^1] = value;
            data = tmp;
        }

        public void Add(params T[] values)
        {
            AddRange(values);
        }

        public void AddRange(ICollection<T> collection)
        {
            T[] tmp = new T[Length + collection.Count];

            for (int i = 0; i < Length; i++)
            {
                tmp[i] = data[i];
            }

            for (int i = 0; i < collection.Count; i++)
            {
                tmp[i + data.Length] = collection.ElementAt(i); 
            }
            
            data = tmp;
        }

        public IEnumerator GetEnumerator()
        {
            return new VectorEnumerator<T>(data);
        }

        public void Remove(int index)
        {
            if(data.Length == 0)
            {
                return;
            }

            var tmp = new T[data.Length - 1];

            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = i >= index ? data[i + 1] : data[i];
            }

            data = tmp;
        }
    }

    internal class Program
    {
        static T Sum<T>(T a, T b)
            where T : ISum
        {
            return (T)a.Sum(b);
        }

        static void PrintValue<T>(T value)
        {
            Console.WriteLine(value);
        }

        static T GenerateValue<T>()
            where T: struct
        {
            T value = new();
            return value;
        }

        static void MyForEach(IEnumerable collection)
        {
            var enumerator = collection.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            enumerator.Reset();
        }

        static void Main(string[] args)
        {
            //PrintValue(1);
            //PrintValue("Hello");
            //PrintValue(new int[] { 1, 2, 3 });


            //DateTime date = GenerateValue<DateTime>();
            //Console.WriteLine(date);

            //var num1 = new Number { Value = 20 };
            //var num2 = new Number { Value = 15 };
            //Number res = Sum(num1, num2);
            //Console.WriteLine(res);


            var colors = new Vector<string>();

            colors.Add("red");
            colors.Add("green");
            colors.Add("blue");
            colors.Add("black");

            foreach (var color in colors)
            {
                Console.WriteLine(color);
            }

            Console.WriteLine("=====================");

            string[] newColors = ["yellow", "purple", "pink", "white"];
            colors.AddRange(newColors);

            foreach (var color in colors)
            {
                Console.WriteLine(color);
            }

            Console.WriteLine("=====================");

            foreach (var color in colors)
            {
                Console.WriteLine(color);
            }


            Console.WriteLine("====== MY FOREACH ========");

            int[] arr = [1, 2, 3, 4, 5, 6];

            MyForEach(arr);
        }
    }
}
