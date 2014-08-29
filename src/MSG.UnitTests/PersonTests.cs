using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class PersonTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> { 23, 16, 1, 38, 47, 1, 3, 9, 3, 3, 247, 6, 13, 3, 9, 2, 8, 6, 7, 2, 1, 8, 1, 3, 187, 52, 8, 2 };
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void PersonTestSingular()
        {
            MoqUtil.SetupRandMock(1);
            Plurality plurality = DomainFactory.Generator.GetRandomPlurality();
            string output = DomainFactory.Generator.GetPerson(plurality);

            Assert.AreEqual("steering committee ", output);
        }

        [Test]
        public void PersonTestSingularWithBoss()
        {
                MoqUtil.SetupRandMock(1, 17, 1, 2, 3, 4, 2, 6);
                Plurality plurality = DomainFactory.Generator.GetRandomPlurality();
                string output = DomainFactory.Generator.GetPerson(plurality);

                Assert.AreEqual("Acting Chief of Management Office ", output);
        }

        [Test]
        public void PersonTestPlural()
        {
            MoqUtil.SetupRandMock(2, 1);
            Plurality plurality = DomainFactory.Generator.GetRandomPlurality();
            string output = DomainFactory.Generator.GetPerson(plurality);

            Assert.AreEqual("key people ", output);
        }

        // GetPluralPersonTests

        [Test]
        public void VerifyResourcesSpacing()
        {
            List<int> defaults = new List<int> { 26, 29, 2, 5, 55, 67, 2, 3, 3, 2, 1, 114, 6, 13, 1, 9, 1, 8, 10, 3, 1, 1, 6, 1, 3, 226, 60, 15, 3 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("The resources target "));
        }

        [Test]
        public void VerifyKeyPeopleSpacing()
        {
            List<int> defaults = new List<int> { 26, 29, 2, 1, 55, 67, 2, 3, 3, 2, 1, 114, 6, 13, 1, 9, 1, 8, 8, 10, 1, 1, 6, 1, 3, 226, 60, 15, 3 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("The key people target "));
        }

        [Test]
        public void VerifyBusinessLeadersSpacing()
        {
            List<int> defaults = new List<int> { 26, 29, 2, 11, 55, 67, 2, 3, 3, 2, 1, 114, 6, 13, 1, 9, 1, 8, 8, 10, 1, 1, 6, 1, 3, 226, 60, 15, 3 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("The business leaders target "));
        }

        [Test]
        public void VerifyCommitteeSpacing()
        {
            _defaults.Insert(3, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("The steering committee manages"));
        }

        [Test]
        public void VerifyChampionSpacing()
        {
            _defaults.Insert(3, 8);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("The powerful champion manages"));
        }

        [Test]
        public void VerifyResourceSpacing()
        {
            _defaults.Insert(3, 11);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("The resource manages"));
        }
    }
}
