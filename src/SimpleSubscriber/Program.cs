using Microsoft.Diagnostics.Tracing.Session;
using Microsoft.Diagnostics.Tracing;

namespace SimpleSubscriber
{
    internal class Program
    {
        private const string ProviderName = "Shyjus-SimpleEventPublisher";

        static void Main(string[] args)
        {
            Console.WriteLine("Starting event subscriber");

            using (var session = new TraceEventSession("MySimpleSession"))
            {
                Console.CancelKeyPress += (object sender, ConsoleCancelEventArgs e) =>
                {
                    Console.WriteLine("Stopping event subscriber...");
                    session.Source.StopProcessing();
                    session.Dispose();
                };

                session.EnableProvider(ProviderName);
                var parser = session.Source.Dynamic;

                parser.All += delegate (TraceEvent data)
                {
                    Console.WriteLine($"Event {data.EventName} received from {data.ProviderName} at level {data.Level}");

                    if (data.EventName == "Foo")
                    {
                        Console.WriteLine($"Foo event received with payload '{data.PayloadByName("Message")}'");
                    }
                    else if (data.EventName == "Bar")
                    {
                        Console.WriteLine($"Bar event received with payload '{data.PayloadByName("Message")}'");
                    }
                };

                session.Source.Process();
            }
        }
    }
}
