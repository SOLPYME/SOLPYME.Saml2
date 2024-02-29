﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SolPyme.Saml2
{
    /// <summary>
    /// Somewhat ugly subclassing to be able to access some methods that are protected
    /// on Saml2SecurityTokenHandler. The public interface of Saml2SecurityTokenHandler
    /// expects the actual assertion to be signed, which is not the case for us since
    /// the entire response message is signed for us instead.
    /// </summary>
    class MorePublicSaml2SecurityTokenHandler : Saml2SecurityTokenHandler
    {
        public new ClaimsIdentity CreateClaims(Saml2SecurityToken samlToken)
        {
            return base.CreateClaims(samlToken);
        }

        private static readonly MorePublicSaml2SecurityTokenHandler defaultInstance
            = new MorePublicSaml2SecurityTokenHandler()
            {
                Configuration = new SecurityTokenHandlerConfiguration()
                {
                    IssuerNameRegistry = new ReturnRequestedIssuerNameRegistry()
                }
            };

        /// <summary>
        /// Get a default of the class, with a default implementation.
        /// </summary>
        public static MorePublicSaml2SecurityTokenHandler DefaultInstance
        {
            get
            {
                return defaultInstance;
            }
        }
    }
}
