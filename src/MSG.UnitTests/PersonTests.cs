using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class PersonTests
    {

        [Test]
        public void PersonTestSingular()
        {
            MoqUtil.SetupRandMock(1);
            string output = DomainFactory.Generator.GetPerson(Plurality.Singular);

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("steering committee", output);
        }

        [Test]
        public void PersonTestPlural()
        {
            MoqUtil.SetupRandMock(1);
            string output = DomainFactory.Generator.GetPerson(Plurality.Plural);

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("key people", output);
        }
    }
}
