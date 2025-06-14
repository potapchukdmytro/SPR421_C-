using MyLib;
using System.Text;

namespace _09_GC
{
    class FileManager : IDisposable
    {
        public FileManager()
        {
            Console.WriteLine("Stream opened");
            Console.WriteLine("File opened");
        }

        public void Write()
        {
            //throw new FileLoadException();
            Console.WriteLine("Data writed");
        }

        // Викликається в кінці роботи з об'єктом
        public void Dispose()
        {
            Console.WriteLine("File saved");
            Console.WriteLine("File closed");
            Console.WriteLine("Stream closed");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(GC.MaxGeneration);
            //Console.WriteLine(GC.GetTotalMemory(true)); // повертає к-сть зайнятих байт

            //var list = new List<int> { 1, 2, 3, 4, 5, 6 };


            //Console.WriteLine("Generation: " + GC.GetGeneration(list)); // отримати покоління об'єкту
            //GC.Collect(); // очищення поколінь
            //Console.WriteLine("Generation: " + GC.GetGeneration(list)); // отримати покоління об'єкту

            //list = new List<int> { 5, 6, 7, 8, 8 };

            //Console.WriteLine("Generation: " + GC.GetGeneration(list)); // отримати покоління об'єкту
            //GC.Collect(); // очищення поколінь
            //Console.WriteLine("Generation: " + GC.GetGeneration(list)); // отримати покоління об'єкту
            //GC.Collect(); // очищення поколінь
            //Console.WriteLine("Generation: " + GC.GetGeneration(list)); // отримати покоління об'єкту

            //Console.WriteLine(GC.GetTotalMemory(false));





            // Dispose
            //FileManager manager = new FileManager();
            //try
            //{
            //    manager.Write();
                
            //}
            //finally
            //{
            //    manager.Dispose();
            //}



            // using - альтернатива try finally
            // using працює тільки з класами які реалізують IDisposable
            using (FileManager manager2 = new FileManager())
            {
                manager2.Write();
            }


            ColoredConsole.WriteLineColored("Colored text", ConsoleColor.Cyan);
        }
    }
}
