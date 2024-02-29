using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Net;

namespace SolPyme.Saml2.Tests
{
    [TestClass]
    public class CommandResultTests
    {
        [TestMethod]
        public void CommandResult_DefaultsTo200()
        {
            var command = new CommandResult();

            command.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
