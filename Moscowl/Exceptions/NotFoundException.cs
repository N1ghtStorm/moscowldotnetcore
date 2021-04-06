using System;

namespace Moscowl.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() {}
        public NotFoundException(string message) : base(message) {}
    }
}
