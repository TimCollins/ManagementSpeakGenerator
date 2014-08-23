using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class PluralityTests
    {
        // Add tests that ensure 1 == singular, 2 == plural.
        // Can probably use an alternative version of one of the tests from 
        // PersonVerbEndingTests.

        [Test]
        public void PersonTestPlural()
        {
            MoqUtil.SetupRandMock(2, 7);
            Plurality plurality = DomainFactory.Generator.GetRandomPlurality();
            string output = DomainFactory.Generator.GetPerson(plurality);

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("enablers ", output);
        }

        [Test]
        public void PersonTestSingular()
        {
            MoqUtil.SetupRandMock(1, 7);
            Plurality plurality = DomainFactory.Generator.GetRandomPlurality();
            string output = DomainFactory.Generator.GetPerson(plurality);

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("enabler ", output);
        }
    }
}
