namespace Host.Interfaces
{
    /// <summary>
    /// A contract for encoder hub client.
    /// </summary>
    public interface IEncoderHubClient
    {
        /// <summary>
        /// Initiate receiving messages for hub clients.
        /// </summary>
        /// <param name="message">A encoded value to be sent to clients.</param>
        /// <returns>A task representing the asynchronous operation call.</returns>
        Task Receive(string message);

        /// <summary>
        /// Completes client processing
        /// </summary>
        /// <returns>A task representing the asynchronous operation call.</returns>
        Task Complete();
    }
}
