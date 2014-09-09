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
        /// <summary>
        /// Verify that when start = 1 and end = 3 that the returned number is 1 or 2.
        /// </summary>
        [Test]
        public void VerifyRangeWhenEndGreaterThanStart()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 3);

            Assert.IsTrue(result > 0 && result < 3);
        }

        /// <summary>
        /// Verify that when start is not specified and end = 2 that the returned number is 0 or 1.
        /// </summary>
        [Test]
        public void VerifyRangeWhenStartNotSpecified()
        {
            int result = DomainFactory.RandomNumber.GetRand(2);

            Assert.IsTrue(result == 0 || result == 1);
        }

        /// <summary>
        /// Verify that when start = 1 and end = 1 that the returned number is 1.
        /// </summary>
        [Test]
        public void VerifyRangeWhenStartEqualToEnd()
        {
            int result = DomainFactory.RandomNumber.GetRand(1, 1);

            Assert.IsTrue(result == 1);
        }

        /// <summary>
        /// Verify that when start = 2 and end = 1 that ArgumentOutOfRangeException is thrown.
        /// </summary>
        [Test]
        public void VerifyExceptionWhenStartGreaterThanEnd()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => DomainFactory.RandomNumber.GetRand(2, 1));
        }

        /// <summary>
        /// Verify that when start = 0 and end = 0 that 0 is returned.
        /// </summary>
        [Test]
        public void ZeroOutputTest()
        {
            int result = DomainFactory.RandomNumber.GetRand(0, 0);

            Assert.AreEqual(0, result);
        }
    }
}
