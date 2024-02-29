﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using FluentAssertions;

namespace SolPyme.Saml2.Tests
{
    [TestClass]
    public class XmlHelpersTests
    {
        [TestMethod]
        public void XmlHelpers_AddAttributeIfNotNullOrEmpty_Adds()
        {
            var e = new XElement("xml");

            e.AddAttributeIfNotNullOrEmpty("attribute", "value");

            e.Attribute("attribute").Should().NotBeNull().And.Subject.Value
                .Should().Be("value");
        }

        [TestMethod]
        public void XmlHelpers_AddAttributeIfNotNullOrEmpty_IgnoresEmpty()
        {
            var e = new XElement("xml");

            e.AddAttributeIfNotNullOrEmpty("attribute", "");

            e.Attribute("attribute").Should().BeNull();
        }

        [TestMethod]
        public void XmlHelpers_AddAttributeIfNotNullOrEmpty_HandlesNamespace()
        {
            var e = new XElement("xml");

            var ns = XNamespace.Get("someNamespace");

            e.AddAttributeIfNotNullOrEmpty(ns + "attribute", "");

            e.Attribute(ns + "attribute").Should().BeNull();
        }

        [TestMethod]
        public void XmlHelpers_AddAttributeIfNotNullOrEmpty_IgnoresNull()
        {
            var e = new XElement("xml");

            e.AddAttributeIfNotNullOrEmpty("attribute", null);

            e.Attribute("attribute").Should().BeNull();
        }

        [TestMethod]
        public void XmlHelpers_AddAttributeIfNotNullOrEmpty_HandlesUri()
        {
            var e = new XElement("xml");

            string uri = "http://some.example.com/";
            e.AddAttributeIfNotNullOrEmpty("attribute", new Uri(uri));

            e.Attribute("attribute").Should().NotBeNull().And.Subject.Value.Should().Be(uri);
        }

        class EmptyToString { public override string ToString() { return string.Empty; } }

        [TestMethod]
        public void XmlHelpers_AddAttributeIfNotNullOrEmpty_IgnoresObjectWithEmptyToString()
        {
            var e = new XElement("xml");

            e.AddAttributeIfNotNullOrEmpty("attribute", new EmptyToString());

            e.Attribute("attribute").Should().BeNull();
        }
    }
}
