using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using ZenView.Core.Internals.ErrorHandling;

namespace ZenView.Core.Models.ClientConfigModels
{
    /// <summary>
    /// Client settings
    /// Target url etc
    /// </summary>
    public class ClientConfig : ClientConfigInternals
    {
        /// <summary>
        /// Will throw a UriException if it can't create and Uri from the provided url.
        /// </summary>
        public ClientConfig(string url = null)
        {
            _targetUri = CreateUriFromUrl(url);
        }

        public Uri Uri { get { return _targetUri; } }

        protected Uri CreateUriFromUrl(string url)
        {
            //Removed try catch, for now, since the if-statement should cover all that can make the new Uri fail
            //If more url parsing is introduced the try catch should be implemented again
            if (!string.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return new Uri(url);
            }
            else
            {
                throw new UriException(ErrorConstants.Uri.InvalidUrl);
            }
        }
    }

    public abstract class ClientConfigInternals
    {
        /// <summary>
        /// The target Uri
        /// </summary>
        internal Uri _targetUri;

        /// <summary>
        /// Users adds custom headers to this dictionary through extensionmethods.
        /// </summary>
        internal Dictionary<string, string> CustomHeaders { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// The protocol to use when making the request
        /// </summary>
        internal SecurityProtocolType ProtocolType { get; set; } = 0;
    }
}