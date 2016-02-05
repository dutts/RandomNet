using System;

namespace RandomNet.Exceptions
{
    public class ConnectionException : ApplicationException
    {
        public ConnectionException(string message, Exception e) : base(message, e)
        {
        }
    }
}
