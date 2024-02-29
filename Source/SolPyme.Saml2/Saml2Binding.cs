﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SolPyme.Saml2
{
    abstract class Saml2Binding
    {
        public abstract CommandResult Bind(Saml2AuthenticationRequest request);

        public abstract bool CanUnbind(HttpRequestBase request);

        private static readonly IDictionary<Saml2BindingType, Saml2Binding> bindings =
            new Dictionary<Saml2BindingType, Saml2Binding>()
            {
                { Saml2BindingType.HttpRedirect, new Saml2RedirectBinding() }
            };

        public static Saml2Binding Get(Saml2BindingType binding)
        {
            return bindings[binding];
        }

        public static Saml2Binding Get(HttpRequestBase request)
        {
            return bindings.FirstOrDefault(b => b.Value.CanUnbind(request)).Value;
        }
    }
}
