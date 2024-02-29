using SolPyme.Saml2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolPyme.Saml2
{
    /// <summary>
    /// Factory to create the command objects thand handles the incoming http requests.
    /// </summary>
    static class CommandFactory
    {
        private static readonly Command notFoundCommand = new NotFoundCommand();

        private static readonly IDictionary<string, Command> commands =
        new Dictionary<string, Command>() { { "SignIn", new SignInCommand() } };

        public static Command GetCommand(string path)
        {
            if (commands.TryGetValue(path, out Command command))
            {
                return command;
            }

            return notFoundCommand;
        }
    }
}
