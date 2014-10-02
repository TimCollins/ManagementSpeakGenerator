using System;

namespace MSG.DomainLogic
{
    public class InvalidSwitchException : Exception
    {
        public InvalidSwitchException(string msg) : base(msg)
        {            
        }
    }
}
