﻿using System;
using System.Linq;
using System.Xml.Linq;

namespace SolPyme.Saml2
{
    static class XmlHelpers
    {
        public static XElement AddAttributeIfNotNullOrEmpty(this XElement xElement, XName attribute, object value)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                xElement.Add(new XAttribute(attribute, value));
            }
            return xElement;
        }
    }
}
