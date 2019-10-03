using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HrApp.API
{
    abstract public class HttpCommand
    {
        protected static string api { get; set; }

        public static void Setup (string endpoint)
        {
            api = endpoint;
        }

        public abstract HttpResponseMessage Execute();
    }
}
