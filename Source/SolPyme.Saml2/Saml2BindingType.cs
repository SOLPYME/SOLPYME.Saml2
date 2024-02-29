﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolPyme.Saml2
{
    /// <summary>
    /// Saml2 binding types.
    /// </summary>
    public enum Saml2BindingType
    {
        /// <summary>
        /// The http redirect binding according to saml bindings section 3.4
        /// </summary>
        HttpRedirect,

        /// <summary>
        /// The http post binding according to saml bindings section 3.5
        /// </summary>
        HttpPost
    }
}
