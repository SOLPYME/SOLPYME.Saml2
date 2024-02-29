using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolPyme.Saml2.Tests
{
    class ConcreteSaml2Request : Saml2RequestBase { }

    [TestClass]
    public class Saml2RequestBaseTests
    {
        [TestMethod]
        public void Saml2RequestBase_Id_IsUnique()
        {
            var r1 = new ConcreteSaml2Request();
            var r2 = new ConcreteSaml2Request();

            r1.Id.Should().NotBe(r2.Id);
        }

        [TestMethod]
        public void Saml2RequestBase_Id_IsValidXsId()
        {
            var id = new ConcreteSaml2Request().Id;

            Regex.IsMatch(id, "[^:0-9][^:]*").Should().BeTrue();
        }
    }
}
