using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class PluralVerbTests
    {
        [Test]
        public void VerifyIdentifies()
        {
            List<int> defaults = new List<int> { 17, 5, 1, 8, 1, 11, 2, 1, 1, 1 };

            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("identifies"));
        }
    }
}
