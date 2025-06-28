using System.Net.Cache;
using System.Text;

namespace _11_Linq
{
    class Student
    {
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Email} - {Age}";
        }
    }

    class Credential
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }


    internal class Program
    {
        static void ExtMethods()
        {
            //Extenstion methods

            int a = 5;
            Console.WriteLine(a.Power(2));

            int b = 10;

            string str = "tEXT";
            Console.WriteLine(str.Capitalize());
        }

        static void PrintCollection<T>(IEnumerable<T> collection, bool endLine = false)
        {
            string separator = endLine ? "\n" : " ";

            foreach (var item in collection)
            {
                Console.Write($"{item}{separator}");
            }
            Console.WriteLine();
        }

        static IEnumerable<T> Pagination<T>(IEnumerable<T> collection, int page, int pageSize)
        {
            double pages = Math.Ceiling((double)collection.Count() / pageSize);

            if(page <= 0 || page > pages)
            {
                page = 1;
            }

            return collection.Skip(pageSize * (page - 1)).Take(pageSize);
        }

        static void QuerySyntax()
        {
            List<int> ints = new List<int> { 2, 5, 6, 86, 3, 2, 46, 8, 98, 4, 2, 5, 79, 4 };

            // синтаксис запитів - query syntax

            // orderby i descending - спадання
            // orderby i ascending - зростання (за замовчуванням)

            var result = from i in ints
                         where i % 2 == 0
                         orderby i descending
                         select i * 2;

            PrintCollection(result);
            Console.WriteLine();

            List<DateTime> dates = new List<DateTime>
            {
                DateTime.Now,
                new DateTime(2020, 2, 20),
                new DateTime(1991, 8, 24),
                new DateTime(2000, 1, 1)
            };

            var dateResult = from date in dates
                             orderby date.Month
                             select date;

            PrintCollection(dateResult, true);
        }

        static void MethodSyntax()
        {
            // Синтаксис методів - Method syntax

            List<Student> students = new List<Student>
            {
                new Student{Email = "student1@gmail.com", Age = 20},
                new Student{Email = "student2@ukr.net", Age = 17},
                new Student{Email = "student3@yahoo.com", Age = 19},
                new Student{Email = "student4@gmail.com", Age = 25},
                new Student{Email = "student5@yahoo.com", Age = 23},
                new Student{Email = "student6@ukr.net", Age = 14},
                new Student{Email = "student7@yahoo.com", Age = 15}
            };
            List<int> ints = new List<int> { 2, 5, 6, 86, 3, 2, 46, 8, 98, 4, 2, 5, 79, 4 };

            // All повертає bool чи всі значення відповідають умові
            bool res = ints.All((int i) => i % 2 == 0);
            Console.WriteLine("All: " + res);

            // All повертає bool чи хоча б одне значення відповідає умові
            res = ints.Any((int i) => i % 2 != 0);
            Console.WriteLine("Any: " + res);

            // Aggregate використовується для обрахунку колекції
            int result = ints.Aggregate(0, (int seed, int value) => seed - value);
            Console.WriteLine(result);

            // Average - середнє арифметичне
            double avg = ints.Average();
            Console.WriteLine(avg);

            // Append - додати елемент; Concat - додати колекцію елементів
            ints = ints.Append(99).ToList();
            PrintCollection(ints);
            Console.WriteLine();

            // Count - повертає к-сть елементів
            int countRes = ints.Count(i => i > 50);
            Console.WriteLine("Count: " + countRes);

            int stResult = students.Count(st => st.Email.Split("@")[1] == "yahoo.com");
            Console.WriteLine("Yahoo: " + stResult);

            // First - Повертає перший елемент або перший елемент який відповідає умові
            // Last - Повертає останній елемент або останній елемент який відповідає умові
            // Якщо елемент не знайдено то згенерується виняток
            int first = ints.First(i => i > 50);
            int last = ints.Last(i => i > 50);
            Console.WriteLine("First: " + first);
            Console.WriteLine("Last: " + last);

            // FirstOrDefault
            // LastOrDefault
            // Якщо елемент не знайдено то повернеться default
            int firstOrDefault = ints.FirstOrDefault(i => i > 50);
            int lastOrDefault = ints.LastOrDefault(i => i > 50);
            Console.WriteLine("firstOrDefault: " + firstOrDefault);
            Console.WriteLine("lastOrDefault: " + lastOrDefault);



            List<Credential> credentials = new List<Credential>
            {
                new Credential{ Login = "user", Password = "qwerty" },
                new Credential{ Login = "admin", Password = "12345678" },
                new Credential{ Login = "boy2025", Password = "boy2025" },
                new Credential{ Login = "angela", Password = "angela222" },
                new Credential{ Login = "mouse", Password = "qazwsx" }
            };

            string userLogin = "boy";
            string userPassword = "boy2020";

            var userCred = credentials.FirstOrDefault(c => c.Login == userLogin);
            if (userCred != null)
            {
                if (userCred.Password == userPassword)
                {
                    Console.WriteLine("Login success");
                }
                else
                {
                    Console.WriteLine("Incorrect password");
                }
            }
            else
            {
                Console.WriteLine("Incorrect login");
            }



            int max = ints.Max();
            Console.WriteLine("Max: " + max);

            Student? maxSt = students.MaxBy(st => st.Age);
            Console.WriteLine("Max student: " + maxSt);


            // Order - сортування
            ints = ints.Order().ToList();
            PrintCollection(ints);

            students = students.OrderBy(st => st.Age).ToList();
            PrintCollection(students, true);


            // Select
            List<int> doubleInts = ints.Select(i => i * 2).ToList();
            PrintCollection(doubleInts);

            List<string> emails = students.Select(st => st.Email).ToList();

            List<string> strInts = ints.Select(i => i.ToString()).ToList();

            Random rnd = new Random();
            int[] randomNumbers = new int[20];
            randomNumbers = randomNumbers.Select(i => rnd.Next(0, 100)).ToArray();
            PrintCollection(randomNumbers);


            // Where
            List<Student> adultStudents = students.Where(st => st.Age >= 18).ToList();
            PrintCollection(adultStudents, true);



            // Take - взяти певну к-сть елементів
            // Skip - пропустити певну к-сть елементів

            Console.WriteLine("Take");
            PrintCollection(ints.Take(5));

            Console.WriteLine("Skip");
            PrintCollection(ints.Skip(5));

            Console.WriteLine("Collection");
            ints = ints.Select(i => rnd.Next(-50, 50)).ToList();
            PrintCollection(ints);

            Console.WriteLine("Page 1");
            IEnumerable<int> page1 = Pagination(ints, 1, 10);
            PrintCollection(page1);

            Console.WriteLine("Page 2");
            IEnumerable<int> page2 = Pagination(ints, 2, 10);
            PrintCollection(page2);

            Console.WriteLine("Page 3");
            IEnumerable<int> page3 = Pagination(ints, 3, 10);
            PrintCollection(page3);

            PrintCollection(students.Pagination(2, 2), true);
        }

        static void Main(string[] args)
        {
            //string filePath = "PFRO.log";
            //string successArg = "Error";

            //string[] lines = File.ReadAllLines(filePath, Encoding.Unicode);

            //string[] successLines = lines
            //    .Where(l => l.Contains(successArg))
            //    .Select(l => l.ToUpper())
            //    .ToArray();

            //foreach (var line in successLines)
            //{
            //    Console.WriteLine(line);
            //}





            string filePath = @"C:\Users\traig\Downloads\5ca1f2fc3ae28.jpg";
            string newFilePath = @"C:\Users\traig\Downloads\test.jpg";

            byte[] img = File.ReadAllBytes(filePath);
            img = img.Concat(img).ToArray();

            using (var ms = new MemoryStream(img))
            {
                using (var stream = new FileStream(newFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    ms.CopyTo(stream);
                }
            }
        }
    }
}
