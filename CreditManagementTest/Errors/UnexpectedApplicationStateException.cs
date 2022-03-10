using System;

namespace CreditManagementTest.Errors
{
    public class UnexpectedApplicationStateException : Exception
    {
        public UnexpectedApplicationStateException(string message): base(message)
        {
            
        }

        public UnexpectedApplicationStateException()
        {
            
        }
    }
}