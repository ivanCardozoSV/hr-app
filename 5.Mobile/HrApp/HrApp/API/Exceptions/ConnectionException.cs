using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.API.Exceptions
{
    class ConnectionException:Exception
    {
        public ConnectionException(string msg) : base(msg)
        {
            message = msg;
        }

        public string message;
    }
}
