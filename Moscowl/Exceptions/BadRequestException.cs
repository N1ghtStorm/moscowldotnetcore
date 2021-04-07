using System;

namespace Moscowl.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() { }
        public BadRequestException(string message) : base(message) { }
    }
}
