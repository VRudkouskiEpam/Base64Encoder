namespace Host.Interfaces
{
    /// <summary>
    /// A contract for simulation of hard time consuming operation.
    /// </summary>
    public interface IProcessingSimulator
    {
        /// <summary>
        /// BuSimulates some hard work..
        /// </summary>
        /// <param name="cancellationToken"></param>
        Task SimulateAsync(CancellationToken cancellationToken);
    }
}
