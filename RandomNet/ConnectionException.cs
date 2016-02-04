using System;

namespace RandomNet
{
    public class ConnectionException : ApplicationException
    {
        public ConnectionException(string message, Exception e) : base(message, e)
        {
        }
    }
}
