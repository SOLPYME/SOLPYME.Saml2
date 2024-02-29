using System;
using System.Linq;
using System.Net;

namespace SolPyme.Saml2
{
    class NotFoundCommand : Command
    {
        public override CommandResult Run()
        {
            return new CommandResult()
            {
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }
    }
}
