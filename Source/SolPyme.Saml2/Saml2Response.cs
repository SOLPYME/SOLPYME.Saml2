﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SolPyme.Saml2
{
    /// <summary>
    /// Represents a SAML2 response according to 3.3.3
    /// </summary>
    public class Saml2Response
    {
        private readonly XmlDocument xmlDocument;

        /// <summary>
        /// Read the supplied Xml and parse it into a response.
        /// </summary>
        /// <param name="xml">xml data.</param>
        /// <returns>Saml2Response</returns>
        /// <exception cref="XmlException">On xml errors or unexpected xml structure.</exception>
        public static Saml2Response Read(string xml)
        {
            var x = new XmlDocument();
            x.LoadXml(xml);

            if (x.FirstChild.LocalName != "Response"
                || x.FirstChild.NamespaceURI != Saml2Namespaces.Saml2P)
            {
                throw new XmlException("Expected a SAML2 assertion document");
            }

            if (x.FirstChild.Attributes["Version"].Value != "2.0")
            {
                throw new XmlException("Wrong or unsupported SAML2 version");
            }

            return new Saml2Response(x);
        }

        private Saml2Response(XmlDocument xml)
        {
            xmlDocument = xml;

            id = xml.FirstChild.Attributes["ID"].Value;

            issueInstant = DateTime.Parse(xml.FirstChild.Attributes["IssueInstant"].Value,
                CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

            var statusString = xml.FirstChild["Status", Saml2Namespaces.Saml2PName]
                ["StatusCode", Saml2Namespaces.Saml2PName].Attributes["Value"].Value;

            status = StatusCodeHelper.FromString(statusString);
        }

        readonly string id;

        /// <summary>
        /// Id of the response message.
        /// </summary>
        public string Id { get { return id; } }

        readonly DateTime issueInstant;

        /// <summary>
        /// Issue instant of the response message.
        /// </summary>
        public DateTime IssueInstant { get { return issueInstant; } }

        readonly Saml2StatusCode status;

        /// <summary>
        /// Status code of the message according to the SAML2 spec section 3.2.2.2
        /// </summary>
        public Saml2StatusCode Status { get { return status; } }

        /// <summary>
        /// Issuer (= sender) of the response.
        /// </summary>
        public string Issuer
        {
            get
            {
                return xmlDocument.FirstChild.Attributes["Issuer"].GetValueIfNotNull();
            }
        }

        /// <summary>
        /// Validates the response.
        /// </summary>
        /// <param name="idpCertificate">Idp certificate that should have signed the reponse</param>
        /// <returns>Is the response signed by the Idp and fulfills other formal requirements?</returns>
        public bool Validate(X509Certificate2 idpCertificate)
        {
            var signedXml = new SignedXml(xmlDocument);

            var signature = xmlDocument.FirstChild["Signature", Saml2Namespaces.DsigName];

            if (signature != null)
            {
                signedXml.LoadXml(signature);

                return signedXml.CheckSignature(idpCertificate, true);
            }
            return false;
        }

        /// <summary>
        /// Extract claims from the assertions contained in the response.
        /// </summary>
        /// <returns>ClaimsIdentities</returns>
        // Method might throw expections so make it a method and not a property.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IEnumerable<ClaimsIdentity> GetClaims()
        {
            foreach (XmlElement assertionNode in xmlDocument.FirstChild.ChildNodes.Cast<XmlElement>()
                .Where(xe => xe.LocalName == "Assertion" && xe.NamespaceURI == Saml2Namespaces.Saml2Name))
            {
                using (var reader = new XmlNodeReader(assertionNode))
                {
                    var token = MorePublicSaml2SecurityTokenHandler.DefaultInstance.ReadToken(reader);

                    yield return MorePublicSaml2SecurityTokenHandler.DefaultInstance
                        .CreateClaims((Saml2SecurityToken)token);
                }
            }
        }
    }
}
