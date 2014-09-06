using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class PluralityTests
    {
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
