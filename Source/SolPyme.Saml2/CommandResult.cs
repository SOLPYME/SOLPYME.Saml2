using System;
using System.Linq;
using System.Net;
using System.Web;

namespace SolPyme.Saml2
{
    class CommandResult
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public HttpCacheability Cacheability { get; set; }
        public Uri Location { get; set; }

        public CommandResult()
        {
            HttpStatusCode = HttpStatusCode.OK;
            Cacheability = HttpCacheability.NoCache;
        }

        public void Apply(HttpResponse response)
        {
            response.Cache.SetCacheability(Cacheability);

            if (HttpStatusCode == System.Net.HttpStatusCode.Found)
            {
                response.Redirect(Location.ToString());
            }

            response.StatusCode = (int)HttpStatusCode;
        }
    }
}
