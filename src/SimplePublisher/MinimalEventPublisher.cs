using SimplePubSub.Shared;
using System.Diagnostics.Tracing;

namespace SimplePublisher
{
    [EventSource(Name = Constants.EventSourceName)]
    public sealed class MinimalEventPublisher : EventSource
    {
        [Event(1)]
        public void Foo(string Message) { WriteEvent(1, Message); }

        public static readonly MinimalEventPublisher Log = new MinimalEventPublisher();
    }
}
