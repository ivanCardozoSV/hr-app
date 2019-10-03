using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.API.Exceptions
{
    class TimeoutException : Exception
    {
        public TimeoutException(string msg) : base(msg)
        {
            message = msg;
        }

        public string message;
    }
}
