﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolPyme.Saml2.Configuration
{
    /// <summary>
    /// Config collection of IdentityProviderElements.
    /// </summary>
    public class IdentityProviderCollection : ConfigurationElementCollection, IEnumerable<IdentityProviderElement>
    {
        /// <summary>
        /// Create new element of right type.
        /// </summary>
        /// <returns>IdentityProviderElement</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new IdentityProviderElement();
        }

        /// <summary>
        /// Get the name of an element.
        /// </summary>
        /// <param name="element">IdentityProviderElement</param>
        /// <returns>element.Name</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((IdentityProviderElement)element).Name;
        }

        /// <summary>
        /// Get a strongly typed enumerator.
        /// </summary>
        /// <returns>Strongly typed enumerator.</returns>
        public new IEnumerator<IdentityProviderElement> GetEnumerator()
        {
            return base.GetEnumerator().AsGeneric<IdentityProviderElement>();
        }
    }
}
