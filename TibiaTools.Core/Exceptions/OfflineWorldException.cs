using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TibiaTools.Core.Exceptions
{
    public class OfflineWorldException : Exception
    {
        public OfflineWorldException()
            : base()
        {

        }

        public OfflineWorldException(string message)
            : base(message)
        {

        }

        public OfflineWorldException(string message, Exception exception)
            : base(message, exception)
        {

        }
    }
}
