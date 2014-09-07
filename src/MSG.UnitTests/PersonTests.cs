using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class PersonTests
    {
        private List<int> _defaults;
        private List<int> _otherSpacingDefaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> { 23, 16, 1, 38, 47, 1, 3, 9, 3, 3, 247, 6, 13, 3, 9, 2, 8, 6, 7, 2, 1, 8, 1, 3, 187, 52, 8, 2 };
            _otherSpacingDefaults = new List<int> { 26, 29, 2,/*here*/55, 67, 2, 3, 3, 2, 1, 114, 6, 13, 1, 9, 1, 8, /*here*/1, 1, 6, 1, 3, 226, 60, 15, 3 };
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
            string output = DomainFactory.Generator.GetPerson(Plurality.Singular);

            Assert.AreEqual("steering committee ", output);
        }

        [Test]
        public void PersonTestSingularWithBoss()
        {
            MoqUtil.SetupRandMock(17, 1, 2, 3, 4, 2, 6);

            string output = DomainFactory.Generator.GetPerson(Plurality.Singular);

            Assert.AreEqual("Acting Chief of Management Office ", output);
        }

        [Test]
        public void PersonTestPlural()
        {
            MoqUtil.SetupRandMock(1);
            string output = DomainFactory.Generator.GetPerson(Plurality.Plural);

            Assert.AreEqual("key people ", output);
        }

        // GetPluralPersonTests

        [Test]
        public void VerifyResourcesSpacing()
        {
            _otherSpacingDefaults.Insert(3, 5);
            _otherSpacingDefaults.Insert(18, 10);
            _otherSpacingDefaults.Insert(19, 3);
            MoqUtil.SetupRandMock(_otherSpacingDefaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The resources target constructive, strategic, key target markets at the end of the day. At the same time, the thought leader interactively thinks across the full value chain across the board.", output);
        }

        [Test]
        public void VerifyKeyPeopleSpacing()
        {
            _otherSpacingDefaults.Insert(3, 1);
            _otherSpacingDefaults.Insert(18, 8);
            _otherSpacingDefaults.Insert(19, 10);
            MoqUtil.SetupRandMock(_otherSpacingDefaults.ToArray());


            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The key people target constructive, strategic, key target markets at the end of the day. At the same time, the thought leader interactively thinks outside the box using a key, efficient, focus.", output);
        }

        [Test]
        public void VerifyBusinessLeadersSpacing()
        {
            _otherSpacingDefaults.Insert(3, 11);
            _otherSpacingDefaults.Insert(18, 8);
            _otherSpacingDefaults.Insert(19, 10);
            MoqUtil.SetupRandMock(_otherSpacingDefaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The business leaders target constructive, strategic, key target markets at the end of the day. At the same time, the thought leader interactively thinks outside the box using a key, efficient, focus.", output);
        }

        [Test]
        public void VerifyCommitteeSpacing()
        {
            _defaults.Insert(3, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The steering committee manages a cost-effective, constructive, focus at the end of the day, while the standard-setters credibly maximise the value throughout the organisation.", output);
        }

        [Test]
        public void VerifyChampionSpacing()
        {
            _defaults.Insert(3, 8);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The powerful champion manages a cost-effective, constructive, focus at the end of the day, while the standard-setters credibly maximise the value throughout the organisation.", output);
        }

        [Test]
        public void VerifyResourceSpacing()
        {
            _defaults.Insert(3, 11);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The resource manages a cost-effective, constructive, focus at the end of the day, while the standard-setters credibly maximise the value throughout the organisation.", output);
        }

        [Test]
        public void GetSingularPersonCase4Singular()
        {
            _otherSpacingDefaults.Insert(3, 5);
            _otherSpacingDefaults.Insert(18, 10);
            _otherSpacingDefaults.Insert(19, 3);
            _otherSpacingDefaults.ReplaceAt(15, 4);
            _otherSpacingDefaults.ReplaceAt(16, 1);
            MoqUtil.SetupRandMock(_otherSpacingDefaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The resources target constructive, strategic, key target markets at the end of the day. At the same time, the intelligence strategically streamlines the process going forward.", output);
        }

        [Test]
        public void GetSingularPersonCase4Plural()
        {
            _otherSpacingDefaults.Insert(3, 5);
            _otherSpacingDefaults.Insert(18, 10);
            _otherSpacingDefaults.Insert(19, 3);
            _otherSpacingDefaults.ReplaceAt(15, 4);
            _otherSpacingDefaults.ReplaceAt(16, 2);
            MoqUtil.SetupRandMock(_otherSpacingDefaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The resources target constructive, strategic, key target markets at the end of the day. At the same time, the organizing principles strategically streamlines the process going forward.", output);
        }
    }
}
