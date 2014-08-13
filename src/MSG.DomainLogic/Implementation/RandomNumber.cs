using System;

namespace MSG.DomainLogic.Implementation
{
    class RandomNumber : IRandomNumber
    {
        private static readonly Random _random = new Random();

        public int GetRand(int start, int end)
        {
            return _random.Next(start, end);
        }

        public int GetRand(int end)
        {
            return GetRand(0, end);
        }
    }
}
