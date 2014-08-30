using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class ReplaceAtTests
    {
        [Test]
        public void ReplaceTestInt()
        {
            List<int> items = new List<int> {17, 8, 2, 8, 6, 11, 3, 5, 12, 8};
            const int expected = 12;
            items.ReplaceAt(4, expected);

            Assert.AreEqual(expected, items[4]);
        }

        [Test]
        public void ReplaceTestString()
        {
            List<string> items = new List<string>{"zero", "one", "two", "three"};
            const string expected = "thing";
            items.ReplaceAt(2, expected);

            Assert.AreEqual(expected, items[2]);
        }

        [Test]
        public void NegativeIndexHandled()
        {
            List<int> items = new List<int> { 17, 8, 2, 8, 6, 11, 3, 5, 12, 8 };

            Assert.Throws<ArgumentOutOfRangeException>(() => items.ReplaceAt(-2, 2));
        }

        [Test]
        public void IndexGreaterThanLengthHandled()
        {
            List<int> items = new List<int> { 17, 8, 2};

            Assert.Throws<ArgumentOutOfRangeException>(() => items.ReplaceAt(3, 2));
        }

        [Test]
        public void NullItemHandled()
        {
            List<string> items = new List<string> { "zero", "one", "two", "three" };

            Assert.Throws<ArgumentNullException>(() => items.ReplaceAt(2, null));
        }
    }
}
