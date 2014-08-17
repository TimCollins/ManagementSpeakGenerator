using System;

namespace MSG.DomainLogic
{
    class RandomNumberException : Exception
    {
        public RandomNumberException(string msg) : base(msg)
        {            
        }
    }
}
