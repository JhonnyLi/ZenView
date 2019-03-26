using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZenView.Core.Internals.ErrorHandling
{
    internal static class ExceptionHelpers
    {
        internal static T ThrowException<T>(string message, Exception innerException)
        {
            throw (Exception)Activator.CreateInstance(typeof(T), message, innerException);
        }
    }

    public static class ErrorConstants
    {
        public static class Uri
        {
            public const string InvalidUrl = "Could not create an Uri from the url provided.";
        }
    }
}