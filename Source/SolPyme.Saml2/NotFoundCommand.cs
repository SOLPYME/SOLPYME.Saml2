using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;

namespace SolPyme.Saml2
{
    class NotFoundCommand : ICommand
    {
        public CommandResult Run(NameValueCollection formData = null)
        {
            return new CommandResult()
            {
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }
    }
}
