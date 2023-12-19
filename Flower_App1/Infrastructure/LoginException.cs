using System;

namespace Flower_App1.Infrastructure
{
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message) { }
    }
}
