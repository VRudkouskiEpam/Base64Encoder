using Host.Interfaces;
using System.Text;

namespace Host.Components
{
    /// <summary>
    /// Base64 encoding implementation of <see cref="IEncoder"/>.
    /// </summary>
    public class Base64Encoder : IEncoder
    {
        /// <inheritdoc/>
        public string Encode(string data)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
