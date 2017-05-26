using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TibiaTools.Core.Exceptions
{
    public class InvalidCharacterException : Exception
    {
        public InvalidCharacterException()
            : base()
        {

        }

        public InvalidCharacterException(string message)
            : base(message)
        {

        }

        public InvalidCharacterException(string message, Exception exception)
            : base(message, exception)
        {

        }
    }
}
