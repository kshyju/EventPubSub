using Microsoft.Diagnostics.Tracing.Session;
using Microsoft.Diagnostics.Tracing;
using SimplePubSub.Shared;

namespace SimpleSubscriber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] providerNames = [Constants.EventSourceName];

            if (args.Length > 0)
            {
                var providers = args[0].Split(',', StringSplitOptions.TrimEntries);
                providerNames.Concat(providers).Distinct().ToArray();
            }

            using (var session = new TraceEventSession("MySimpleSession"))
            {
                Console.CancelKeyPress += (object sender, ConsoleCancelEventArgs e) =>
                {
                    Console.WriteLine("Stopping event subscriber...");
                    session.Source.StopProcessing();
                    session.Dispose();
                };

                Console.WriteLine($"Starting event subscriber for {providerNames.Length} provider(s).");
                foreach (var providerName in providerNames)
                {
                    Console.WriteLine($"{providerName}");
                    session.EnableProvider(providerName);
                }
                Console.WriteLine(Environment.NewLine);

                var parser = session.Source.Dynamic;

                parser.All += delegate (TraceEvent data)
                {
                    Console.WriteLine($"Event '{data.EventName}'({data.ID})received from {data.ProviderName}({data.ProviderGuid}) at level {data.Level}");

                    if (data.EventName == "Foo")
                    {
                        Console.WriteLine($"Foo event received with payload '{data.PayloadByName("Message")}' {Environment.NewLine}");
                    }
                };

                session.Source.Process();
            }
        }
    }
}
