using System;

namespace MSG.DomainLogic
{
    public class UnsupportedSwitchException : Exception
    {
        public UnsupportedSwitchException(string msg) : base(msg)
        {            
        }
    }
}

