﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace SolPyme.Saml2.Tests
{
    [TestClass]
    public class IdentityProviderTests
    {
        [TestMethod]
        public void IdentityProvider_CreateAuthenticateRequest_Destination()
        {
            string idpUri = "http://idp.example.com/";

            var ip = new IdentityProvider()
            {
                DestinationUri = new Uri(idpUri)
            };

            var r = ip.CreateAuthenticateRequest();

            r.ToXElement().Attribute("Destination").Should().NotBeNull()
                .And.Subject.Value.Should().Be(idpUri);
        }

        [TestMethod]
        public void IdentityProvider_CreateAuthenticateRequest_AssertionConsumerServiceUrlFromConfig()
        {
            var idp = IdentityProvider.ConfiguredIdentityProviders.First().Value;

            var r = idp.CreateAuthenticateRequest();

            r.AssertionConsumerServiceUrl.Should().Be(new Uri("http://localhost/Saml2AuthenticationModule/acs"));
        }
    }
}
