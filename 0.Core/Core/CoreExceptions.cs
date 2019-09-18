using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class CoreExceptionConstants
    {
        public static readonly string InvalidSettingMessage = "Invalid setting; {0}.";
    }

    public class InvalidSettingException : Exception
    {
        public InvalidSettingException(string message) : base(message) { }
    }
}
