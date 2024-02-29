using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Net;
using SolPyme.Saml2;

namespace SolPyme.Saml2.Tests
{
    [TestClass]
    public class NotFoundCommandTests
    {
        [TestMethod]
        public void NotFoundCommand_Run_Sets404()
        {
            var command = new NotFoundCommand();
            var result = command.Run();

            result.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
