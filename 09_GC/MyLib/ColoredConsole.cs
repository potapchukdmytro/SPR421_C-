namespace MyLib
{
    public static class ColoredConsole
    {
        public static void WriteLineColored(object obj, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(obj.ToString());
            Console.ResetColor();
        }
    }
}
