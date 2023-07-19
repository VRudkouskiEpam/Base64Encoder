using Host.Interfaces;

namespace Host.Components
{
    /// <summary>
    /// An implementation of <see cref="IEncodingProcessor"/> for processing encoding by chunks. 
    /// </summary>
    public class ChunkedEncodingProcessor : IEncodingProcessor
    {
        private readonly IEncoder _encoder;
        private readonly IProcessingSimulator _processingSimulator;

        /// <summary>
        /// Constructs <see cref="ChunkedEncodingProcessor"/> instance.
        /// </summary>
        /// <param name="encoder">An instance of <see cref="IEncoder"/></param>
        /// <param name="messageBuilder">An instance of <see cref="IProcessingSimulator"/></param>
        public ChunkedEncodingProcessor(IEncoder encoder, IProcessingSimulator messageBuilder)
        {
            _encoder = encoder;
            _processingSimulator = messageBuilder;
        }

        /// <inheritdoc/>
        public async Task ProcessAsync(string data, Func<string, Task> callback, CancellationToken cancellationToken)
        {
            string chunks = _encoder.Encode(data);

            foreach (var chunk in chunks)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // Simulate a kind of hard operation.
                await _processingSimulator.SimulateAsync(cancellationToken);

                await callback(chunk.ToString());
            }
        }
    }
}
