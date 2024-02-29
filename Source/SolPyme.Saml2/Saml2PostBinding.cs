using System;
using System.Linq;
using System.Text;
using System.Web;

namespace SolPyme.Saml2
{
    class Saml2PostBinding : Saml2Binding
    {
        protected override bool CanUnbind(System.Web.HttpRequestBase request)
        {
            return request.HttpMethod == "POST"
                && request.Form.AllKeys.Contains("SAMLResponse");
        }

        public override Saml2Response Unbind(HttpRequestBase request)
        {
            Convert.FromBase64String(request.Form["SAMLResponse"]);

            throw new NotImplementedException();
        }
    }
}
