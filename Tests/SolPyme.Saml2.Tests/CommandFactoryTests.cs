﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace SolPyme.Saml2.Tests
{
    [TestClass]
    public class CommandFactoryTests
    {
        [TestMethod]
        public void CommandFactory_Invalid_ReturnsNotFound()
        {
            CommandFactory.GetCommand().Should().BeOfType<NotFoundCommand>();
        }
    }
}
