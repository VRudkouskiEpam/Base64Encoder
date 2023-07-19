namespace Host.Interfaces
{
    /// <summary>
    /// A contract to manage encoding process.
    /// </summary>
    public interface IEncodingProcessor
    {
        /// <summary>
        /// Encodes input data
        /// </summary>
        /// <param name="data">Data to be encoded.</param>
        /// <param name="callback">Callback function for processed message.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task representing the asynchronous operation call.</returns>
        /// <exception cref="OperationCanceledException">
        /// The <paramref name="cancellationToken"/> was canceled.
        /// </exception>
        Task ProcessAsync(string data, Func<string, Task> callback, CancellationToken cancellationToken);
    }
}
