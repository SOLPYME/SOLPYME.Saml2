﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolPyme.Saml2
{
    /// <summary>
    /// Base class for saml requests, corresponds to section 3.2.1 in SAML Core specification.
    /// </summary>
    public abstract class Saml2RequestBase
    {
        private readonly string id = "id" + Guid.NewGuid().ToString("N");

        /// <summary>
        /// The id of the request.
        /// </summary>
        public string Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Version of the SAML request. Always returns "2.0"
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public string Version
        {
            get
            {
                return "2.0";
            }
        }

        private readonly string issueInstant =
            DateTime.UtcNow.ToString("s", CultureInfo.InvariantCulture) + "Z";

        /// <summary>
        /// The instant that the request was issued (well actually, created).
        /// </summary>
        public string IssueInstant
        {
            get
            {
                return issueInstant;
            }
        }
    }
}
