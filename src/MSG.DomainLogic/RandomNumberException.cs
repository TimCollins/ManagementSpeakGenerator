using System;

namespace MSG.DomainLogic
{
    public class RandomNumberException : Exception
    {
        public RandomNumberException(string msg) : base(msg)
        {            
        }
    }
}
