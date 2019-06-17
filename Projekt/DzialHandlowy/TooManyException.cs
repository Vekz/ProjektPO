using System;

namespace Projekt1
{
    public class TooManyException : Exception
    {
        public TooManyException()
        {
        }

        public TooManyException(string message)
            : base(message)
        {
        }

        public TooManyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
