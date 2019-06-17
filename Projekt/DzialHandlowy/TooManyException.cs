using System;

namespace Projekt1
{
    /// <summary>
    /// Wyjątek wyrzucany w momencie gdy wartość podana powodu odjęcie za dużej wartości
    /// </summary>
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
