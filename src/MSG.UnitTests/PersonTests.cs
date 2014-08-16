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
            string output = DomainFactory.Generator.GetPerson();

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("steering committee", output);
        }

        [Test]
        public void PersonTestSingularWithBoss()
        {
                MoqUtil.SetupRandMock(1, 17, 1, 2, 3, 4, 2, 6);
                string output = DomainFactory.Generator.GetPerson();

                MoqUtil.UndoMockRandomNumber();

                Assert.AreEqual("Acting Chief of Management Office", output);
        }

        [Test]
        public void PersonTestPlural()
        {
            MoqUtil.SetupRandMock(2, 1);
            string output = DomainFactory.Generator.GetPerson();

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("key people", output);
        }
    }
}
