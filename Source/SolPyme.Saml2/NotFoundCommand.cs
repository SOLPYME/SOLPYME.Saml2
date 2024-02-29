using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;

namespace SolPyme.Saml2
{
    class NotFoundCommand : ICommand
    {
        public CommandResult Run(HttpRequestBase request)
        {
            return new CommandResult()
            {
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }
    }
}
