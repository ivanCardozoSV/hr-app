using System;
using System.Collections.Generic;
using System.Text;

namespace HrApp.API.Exceptions
{
    class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string msg) : base(msg)
        {
            message = msg;
        }

        public string message;
    }
}
