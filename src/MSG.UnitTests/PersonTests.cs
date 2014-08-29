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
            Plurality plurality = DomainFactory.Generator.GetRandomPlurality();
            string output = DomainFactory.Generator.GetPerson(plurality);

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("steering committee ", output);
        }

        [Test]
        public void PersonTestSingularWithBoss()
        {
                MoqUtil.SetupRandMock(1, 17, 1, 2, 3, 4, 2, 6);
                Plurality plurality = DomainFactory.Generator.GetRandomPlurality();
                string output = DomainFactory.Generator.GetPerson(plurality);

                MoqUtil.UndoMockRandomNumber();

                Assert.AreEqual("Acting Chief of Management Office ", output);
        }

        [Test]
        public void PersonTestPlural()
        {
            MoqUtil.SetupRandMock(2, 1);
            Plurality plurality = DomainFactory.Generator.GetRandomPlurality();
            string output = DomainFactory.Generator.GetPerson(plurality);

            MoqUtil.UndoMockRandomNumber();

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
            //List<int> defaults = new List<int> { 26, 29, 2, 11, 55, 67, 2, 3, 3, 2, 1, 114, 38, 13, 1, 40, 1, 8, 79, 79, 1, 1, 6, 1, 3, 226, 60, 15, 3 };
            List<int> defaults = new List<int> { 26, 29, 2, 11, 55, 67, 2, 3, 3, 2, 1, 114, 6, 13, 1, 9, 1, 8, 8, 10, 1, 1, 6, 1, 3, 226, 60, 15, 3 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("The business leaders target "));
        }

        //[Test]
        //public void Something()
        //{
        //    List<int> defaults = new List<int> {27, 99, 9, 1, 7, 79, 46, 2, 3, 7, 1, 3, 45, 49, 15, 2};
        //    MoqUtil.SetupRandMock(defaults.ToArray());

        //    string output = DomainFactory.Generator.GetSentences(1)[0];

        //    Assert.IsTrue(output.Contains("the business leaders streamline "));
        //}

        [Test]
        public void VerifyCommitteeSpacing()
        {
            List<int> defaults = new List<int> { 23, 16, 1, 1, 38, 47, 1, 3, 9, 3, 3, 247, 65, 13, 3, 50, 2, 8, 48, 48, 2, 1, 8, 1, 3, 187, 52, 8, 2 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("steering committee "));
        }

        [Test]
        public void VerifyChampionSpacing()
        {
            List<int> defaults = new List<int> { 23, 16, 1, 8, 38, 47, 1, 3, 9, 3, 3, 247, 65, 13, 3, 50, 2, 8, 48, 48, 2, 1, 8, 1, 3, 187, 52, 8, 2 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("powerful champion "));
        }

        [Test]
        public void VerifyResourceSpacing()
        {
            List<int> defaults = new List<int> { 23, 16, 1, 11, 38, 47, 1, 3, 9, 3, 3, 247, 65, 13, 3, 50, 2, 8, 48, 48, 2, 1, 8, 1, 3, 187, 52, 8, 2 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("resource "));
        }
    }
}
