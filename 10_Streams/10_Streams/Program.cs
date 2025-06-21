using System.Text;

namespace _10_Streams
{
    internal class Program
    {
        static string ReadFile(string path)
        {
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[stream.Length];
                    int l = stream.Read(buffer);

                    string data = Encoding.UTF8.GetString(buffer);
                    return data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }

        static void WriteFile(string path, string data)
        {
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(data);
                    stream.Write(bytes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CopyImage(string fromPath, string toPath)
        {
            try
            {
                using (FileStream streamRead = new FileStream(fromPath, FileMode.Open, FileAccess.Read))
                {
                    byte[] imageBytes = new byte[streamRead.Length];
                    int l = streamRead.Read(imageBytes);

                    using (FileStream streamWrite = new FileStream(toPath, FileMode.Create, FileAccess.Write))
                    {
                        streamWrite.Write(imageBytes, 0, 450000);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // FileStream

            //string fileText = ReadFile("data.txt");
            //Console.WriteLine(fileText);

            //WriteFile("text.txt", "Привіт цей текст був записаний мовою C#");

            //CopyImage("image.jpeg", "image2.jpeg");





            // Робота з текстовими файлами

            // StreamReader - використовується для читання тексту з файлу
            //string filePath = "text.txt";

            //using (StreamReader sr = new StreamReader(filePath))
            //{
            //    string fileText = sr.ReadToEnd();
            //    Console.WriteLine(fileText);
            //}

            // StreamWriter - використовується для запису тексту у файл
            //string filePath2 = "text2.txt";
            //using (StreamWriter sw = new StreamWriter(filePath2))
            //{
            //    sw.WriteLine("Тестуємо StreamWriter");
            //}






            // Бінарний stream

            //using(FileStream stream = new FileStream("image.webp", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //using(BinaryReader br = new BinaryReader(stream))
            //{
            //    byte[] bytes = br.ReadBytes((int)stream.Length);

            //    foreach (var b in bytes)
            //    {
            //        Console.Write(b);
            //    }
            //}


            //using (FileStream stream = new FileStream("number.spr421", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //using(BinaryWriter bw = new BinaryWriter(stream))
            //{
            //    bw.Write(421002434);
            //}





        }
    }
}
