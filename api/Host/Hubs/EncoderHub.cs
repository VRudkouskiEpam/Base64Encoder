using Host.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Host.Hubs
{
    /// <summary>
    /// The encoder hub implementation.
    /// </summary>
    public class EncoderHub : Hub<IEncoderHubClient>
    {
        private readonly IEncodingProcessor _encodingProcessor;

        /// <summary>
        /// Constructs an instance of <see cref="EncoderHub"/>.
        /// </summary>
        /// <param name="encodingProcessor">An instance of <see cref="IEncodingProcessor"/></param>
        public EncoderHub(IEncodingProcessor encodingProcessor)
        {
            _encodingProcessor = encodingProcessor;
        }

        /// <summary>
        /// Processes data encoding request.
        /// </summary>
        /// <param name="data">Data to be encoded.</param>
        /// <param name="connectionId">The connection identifier.</param>
        /// <returns>
        /// A task representing the asynchronous operation call.
        /// </returns>
        public async Task Send(string data, string connectionId)
        {
            IEncoderHubClient client = Clients.Client(connectionId);

            await _encodingProcessor.ProcessAsync(data, client.Receive, Context.ConnectionAborted);

            await client.Complete();
        }

        /// <summary>
        /// Gets connection identifier.
        /// </summary>
        /// <returns>
        /// A string value that represents connection identifier.
        /// </returns>
        public string GetConnectionId() => Context.ConnectionId;
    }
}
