using System;

namespace SageOneApi.Client.Utils
{
    /// <summary>
    /// Like <seealso cref="Progress{T}"/> but without the asyncness.
    /// </summary>
    /// <remarks>With <seealso cref="Progress{T}"/> you get fire-and-forget event handling making use of the synchronization context, but your events may arrive out of order; if you use this class instead, the calling process is stalled while the event is handled, but your events will be handled strictly in the order in which they happened.</remarks>
    internal class SynchronousProgressHandler<T>(Action<T> action) : IProgress<T>
    {
        private readonly Action<T> _action = action
                ?? throw new ArgumentNullException(nameof(action), $"Value required for {nameof(SynchronousProgressHandler<T>)} {nameof(action)}.");

        public void Report(T value)
            => _action(value);
    }
}
