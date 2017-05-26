using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TibiaTools.Core.Exceptions
{
    public class InvalidWorldException : Exception
    {
        public InvalidWorldException()
            : base()
        {

        }

        public InvalidWorldException(string message)
            : base(message)
        {

        }

        public InvalidWorldException(string message, Exception exception)
            : base(message, exception)
        {

        }
    }
}
