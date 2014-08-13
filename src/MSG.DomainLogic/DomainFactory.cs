using MSG.DomainLogic.Implementation;
using MSG.DomainLogic.Interfaces;

namespace MSG.DomainLogic
{
    public class DomainFactory
    {
        private static IRandomNumber _randomNumber;
        private static IGenerator _generator;

        public static IRandomNumber RandomNumber
        {
            get { return _randomNumber ?? (_randomNumber = new RandomNumber()); }
            set { _randomNumber = value; }
        }

        public static IGenerator Generator
        {
            get { return _generator ?? (_generator = new Generator()); }
            set { _generator = value; }
        }
    }
}
