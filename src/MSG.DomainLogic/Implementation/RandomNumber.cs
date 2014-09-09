using System;
using System.IO;
using MSG.DomainLogic.Interfaces;

namespace MSG.DomainLogic.Implementation
{
    class RandomNumber : IRandomNumber
    {
        private static readonly Random _random = new Random();
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "\\rolls.txt";

        public int GetRand(int start, int end)
        {
            int r = _random.Next(start, end);
            using (StreamWriter sw = new StreamWriter(_fileName, true))
            {
                sw.Write("{0},", r);
            }
            return r;
        }

        public int GetRand(int end)
        {
            return GetRand(0, end);
        }
    }
}
