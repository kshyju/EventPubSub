namespace SimplePublisher
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Simple event publisher. Will send Foo and Bar event every second for 10 seconds.");

            for(var i = 0; i < 10; i++)
            {
                MinimalEventPublisher.Log.Foo($"Foo {i}");
                MinimalEventPublisher.Log.Bar($"Bar {i}");
                Console.WriteLine($"Sent Foo and Bar event {i}");
                await Task.Delay(1000);
            }
            Console.WriteLine("Exiting simple event publisher");
        }
    }
}
