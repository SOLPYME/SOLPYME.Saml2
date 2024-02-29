using System;
using System.Linq;
using System.Net;
using System.Web;

namespace SolPyme.Saml2
{
    class CommandResult
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public CommandResult()
        {
            HttpStatusCode = HttpStatusCode.OK;
        }

        public void Apply(HttpResponse response)
        {
            response.StatusCode = (int)HttpStatusCode;
        }
    }
}
