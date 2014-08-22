using System.Collections.Generic;
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

                Assert.AreEqual("Acting Chief of Management Office ", output);
        }

        [Test]
        public void PersonTestPlural()
        {
            MoqUtil.SetupRandMock(2, 1);
            string output = DomainFactory.Generator.GetPerson();

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("key people", output);
        }

        // GetPluralPersonTests

        [Test]
        public void VerifyResourcesSpacing()
        {
            List<int> _defaults = new List<int> { 26, 29, 2, 5, 55, 67, 2, 3, 3, 2, 1, 114, 38, 13, 1, 40, 1, 8, 79, 79, 1, 1, 6, 1, 3, 226, 60, 15, 3 };
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("the resources streamline "));
        }

        [Test]
        public void VerifyKeyPeopleSpacing()
        {
            List<int> _defaults = new List<int> { 26, 29, 2, 1, 55, 67, 2, 3, 3, 2, 1, 114, 38, 13, 1, 40, 1, 8, 79, 79, 1, 1, 6, 1, 3, 226, 60, 15, 3 };
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("the key people streamline "));
        }

        [Test]
        public void VerifyBusinessLeadersSpacing()
        {
            List<int> _defaults = new List<int> { 26, 29, 2, 11, 55, 67, 2, 3, 3, 2, 1, 114, 38, 13, 1, 40, 1, 8, 79, 79, 1, 1, 6, 1, 3, 226, 60, 15, 3 };
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("the business leaders streamline "));
        }
    }
}
