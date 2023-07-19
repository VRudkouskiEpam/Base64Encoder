namespace Host.Interfaces
{
    /// <summary>
    /// Basic encoder contract.
    /// </summary>
    public interface IEncoder
    {
        /// <summary>
        /// Encodes provided data.
        /// </summary>
        /// <param name="data">Data to be encoded.</param>
        /// <returns>
        /// A string that represents encoded value.
        /// </returns>
        string Encode(string data);
    }
}