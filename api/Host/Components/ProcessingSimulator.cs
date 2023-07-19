using Host.Interfaces;
namespace Host.Components
{
    /// <summary>
    /// An implementation of <see cref="IProcessingSimulator"/>
    /// </summary>
    public class ProcessingSimulator : IProcessingSimulator
    {
        private const int MinDelayInSeconds = 1;
        private const int MaxDelayInSeconds = 5;

        /// <inheritdoc/>
        public Task SimulateAsync(CancellationToken cancellationToken)
        {
            Random random = new();
            int delay = random.Next(MinDelayInSeconds * 1000, MaxDelayInSeconds * 1000);
            Task.Delay(delay, cancellationToken).Wait(cancellationToken);
            return Task.CompletedTask;
        }
    }
}
