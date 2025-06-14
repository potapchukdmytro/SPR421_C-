namespace async_await
{
    internal class Program
    {
        static Task<int> RandomNumberAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(5000);
                return new Random().Next(0, 100);
            });
        }

        static async Task Main(string[] args)
        {
            var res = await RandomNumberAsync();

            Console.WriteLine(res);
            Console.WriteLine("End");
        }
    }
}
