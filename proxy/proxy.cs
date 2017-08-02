using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace proxy
{
    public class MyHttpProxy : IWebProxy
    {

        public MyHttpProxy()
        {
            this.ProxyUri = new Uri("http://127.0.0.1:8888"); //Fiddler Proxy
        }

        public Uri ProxyUri { get; set; }

        public ICredentials Credentials { get; set; }

        public Uri GetProxy(Uri destination)
        {
            return this.ProxyUri;
        }

        public bool IsBypassed(Uri host)
        {
            //you can proxy all requests or implement bypass urls based on config settings
            return false;

        }
    }
}
