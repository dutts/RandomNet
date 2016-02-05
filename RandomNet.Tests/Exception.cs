using System;

namespace RandomNet.Tests
{
    public static class ExceptionTestExtension
    {
        public static bool ContainsInnerExceptionOfType(this Exception e, Type t)
        {
            if (e.InnerException == null) return false;

            return (e.InnerException.GetType() == t) || ContainsInnerExceptionOfType(e.InnerException, t);
        }
    }
}
