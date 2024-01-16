namespace SimplePublisher
{
    internal class Program
    {
        private const int numberOfSecondsToRun = 30;

        static async Task Main(string[] args)
        {
            Console.WriteLine($"Starting Simple event publisher. Will send Foo and Bar event every second for {numberOfSecondsToRun} seconds.");

            for(var i = 0; i < numberOfSecondsToRun; i++)
            {
                MinimalEventPublisher.Log.Foo($"Foo {i} at {DateTime.Now}");
                MinimalEventPublisher.Log.Bar($"Bar {i} at {DateTime.Now}");
                Console.WriteLine($"Sent Foo and Bar event {i}");
                await Task.Delay(1000);
            }
            Console.WriteLine("Exiting simple event publisher");
        }
    }
}
