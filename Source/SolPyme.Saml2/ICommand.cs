using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace SolPyme.Saml2
{
    interface ICommand
    {
        CommandResult Run(HttpRequestBase request);
    }
}
