using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolPyme.Saml2
{
    abstract class Command
    {
        public abstract CommandResult Run();
    }
}
