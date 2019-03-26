using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZenView.Core.Internals.ErrorHandling
{
    [Serializable]
    public class UriException : Exception
    {
        public UriException()
        {
        }

        public UriException(string message) : base(message)
        {
        }

        public UriException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}