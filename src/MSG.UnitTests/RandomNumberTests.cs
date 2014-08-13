using System;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    /// <summary>
    /// Unit tests against the random number class.
    /// </summary>
    class RandomNumberTests
    {
        [Test]
        public void VerifyRangeWhenEndGreaterThanStart()
        {
            // Verify that when start = 1 and end = 3 that the returned number is 1 or 2.
            int result = DomainFactory.RandomNumber.GetRand(1, 3);

            Assert.IsTrue(result > 0 && result < 3);
        }

        [Test]
        public void VerifyRangeWhenStartNotSpecified()
        {
            // Verify that when start is not specified and end = 2 that the returned number is 0 or 1.
            int result = DomainFactory.RandomNumber.GetRand(2);

            Assert.IsTrue(result == 0 || result == 1);
        }

        [Test]
        public void VerifyRangeWhenStartEqualToEnd()
        {
            // Verify that when start = 1 and end = 1 that the returned number is 1.
            int result = DomainFactory.RandomNumber.GetRand(1, 1);

            Assert.IsTrue(result == 1);
        }

        [Test]
        public void VerifyExceptionWhenStartGreaterThanEnd()
        {
            // Verify that when start = 2 and end = 1 that ArgumentOutOfRangeException is thrown.
            Assert.Throws<ArgumentOutOfRangeException>(() => DomainFactory.RandomNumber.GetRand(2, 1));
        }
    }
}
