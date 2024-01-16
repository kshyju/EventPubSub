using System.Diagnostics.Tracing;

namespace SimplePublisher
{
    [EventSource(Name = "Shyjus-SimpleEventPublisher")]
    public sealed class MinimalEventPublisher : EventSource
    {
        [Event(1, Level = EventLevel.Informational)]
        public void Foo(string Message) { WriteEvent(1, Message); }

        [Event(2)]
        public void Bar(string Message) { WriteEvent(2, Message); }

        public static readonly MinimalEventPublisher Log = new MinimalEventPublisher();
    }
}
