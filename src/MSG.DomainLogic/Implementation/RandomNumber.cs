using System;
using System.IO;
using MSG.DomainLogic.Interfaces;

namespace MSG.DomainLogic.Implementation
{
    class RandomNumber : IRandomNumber
    {
        private static readonly Random _random = new Random();

        public int GetRand(int start, int end)
        {
            int r = _random.Next(start, end);
#if DEBUG
            string _fileName = Directory.GetCurrentDirectory() + "\\rolls.txt";

            using (StreamWriter sw = new StreamWriter(_fileName, true))
            {
                sw.Write(r == 0 ? Environment.NewLine : string.Empty);
                sw.Write("{0},", r);
            }
#endif
            return r;
        }

        public int GetRand(int end)
        {
            return GetRand(0, end);
        }
    }
}
