using System.Text;

namespace _10_File_Path_Directory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Directory - робота з директоріями
            //Console.WriteLine(Directory.GetCurrentDirectory());

            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            // Path - робота зі шляхами
            string root = Directory.GetCurrentDirectory();
            string imagesPath = Path.Combine(root, "data", "images");


            // File - робота із файлами
            //File.WriteAllText("fileTest.txt", "string root = Directory.GetCurrentDirectory();");
            //string text = File.ReadAllText(@"C:\itstep\3 семестр\SPR421\C#\09_home.txt");
            //Console.WriteLine(text);




            // DirectoryInfo
            //DirectoryInfo directory = new DirectoryInfo("C:\\itstep\\3 семестр\\SPR421\\C#\\code");
            //Console.WriteLine(directory.Parent);
            //Console.WriteLine(directory.Name);
            //Console.WriteLine(directory.FullName);
            //Console.WriteLine(directory.CreationTime);
            //Console.WriteLine(directory.Root);

            //var children = directory.GetDirectories();

            //foreach (var child in children)
            //{
            //    Console.WriteLine(child.Name);
            //}




            // FileInfo
            //FileInfo file = new FileInfo(@"C:\itstep\3 семестр\SPR421\C#\code\.gitignore");
            //Console.WriteLine(file.Extension);






            FileManager fm = new FileManager();

            while(true)
            {
                Console.Clear();
                fm.PrintChildren();

                var key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.UpArrow)
                {
                    fm.Move(Direction.Up);
                }
                else if(key.Key == ConsoleKey.DownArrow)
                {
                    fm.Move(Direction.Down);
                }
                else if(key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if(key.Key == ConsoleKey.Enter)
                {
                    fm.Enter();
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    fm.Back();
                }
            }
        }
    }
}
