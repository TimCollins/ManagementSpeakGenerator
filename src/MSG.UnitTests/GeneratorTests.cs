using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class GeneratorTests
    {
        [Test]
        public void VerifyBlankManaging()
        {
            MoqUtil.SetupRandMock(1, 7, 2, 2, 3, 2, 14);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Head of Marketing ", boss);
        }

        [Test]
        public void VerifySpacingInManagingHead()
        {
            MoqUtil.SetupRandMock(1, 1, 2, 2, 3, 2, 14);
            
            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Managing Head of Marketing ", boss);
        }

        [Test]
        public void VerifySpacingInActingHead()
        {
            MoqUtil.SetupRandMock(1, 2, 2, 2, 3, 2, 5);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Acting Head of Operations ", boss);
        }

        [Test]
        public void VerifyDirectorTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 1, 17, 4);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Director of Legal ", boss);
        }

        [Test]
        public void VerifyChiefTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 2, 7);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Chief of Customer Relations ", boss);
        }

        [Test]
        public void VerifyHeadTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 3, 17, 4);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Head of Legal ", boss);
        }

        [Test]
        public void VerifyCoHeadTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 3, 1, 5);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Co-Head of Operations ", boss);
        }

        [Test]
        public void VerifyPresidentTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 4, 17, 7);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("President of Customer Relations ", boss);
        }

        [Test]
        public void VerifyVicePresidentTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 4, 8, 14);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Vice President of Marketing ", boss);
        }

        [Test]
        public void VerifyCorporateVicePresidentTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 4, 11, 13);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Corporate Vice President of IT Operations ", boss);
        }

        [Test]
        public void VerifySeniorAge()
        {
            MoqUtil.SetupRandMock(1, 3, 1, 2, 4, 8, 7);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Senior Vice President of Customer Relations ", boss);
        }

        [Test]
        public void VerifyNoSeniorAge()
        {
            MoqUtil.SetupRandMock(1, 3, 1, 2, 4, 8, 14);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Senior Vice President of Marketing ", boss);
        }

        [Test]
        public void VerifySeniorExecutive()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 1, 2, 7);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Executive Chief of Customer Relations ", boss);
        }

        [Test]
        public void VerifyNoSeniorExecutive()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 2, 4);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Chief of Legal ", boss);
        }

        [Test]
        public void VerifyDepartment()
        {
            MoqUtil.SetupRandMock(1, 2, 2, 2, 3, 2, 9);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Acting Head of Client Relationship ", boss);
        }

        [Test]
        public void VerifySpacingInActingSeniorExecutiveHead()
        {
            MoqUtil.SetupRandMock(1, 2, 1, 1, 3, 2, 12);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Acting Senior Executive Head of IT Strategy ", boss);
        }

        [Test]
        public void VerifySpacingInManagingDirector()
        {
            MoqUtil.SetupRandMock(1, 1, 2, 2, 1, 12, 10);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Managing Director of Business Planning ", boss);
        }

        [Test]
        public void VerifyBoss()
        {
            MoqUtil.SetupRandMock(1, 2, 1, 1, 3, 12, 12);

            string boss = DomainFactory.Generator.GetBoss();

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Acting Senior Executive Head of IT Strategy ", boss);

            Assert.IsNotNull(boss);
        }

        [Test]
        public void VerifyBossAlt()
        {
            MoqUtil.SetupRandMock(2, 1, 17);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Group Chief Technical Officer ", boss);

            Assert.IsNotNull(boss);
        }

        [Test]
        public void VerifyChiefSpacing()
        {
            // Titles like " Chief Operations Officer" should not have a space at the start.
            MoqUtil.SetupRandMock(2, 3, 14, 5);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Chief Operations Officer ", boss);

            Assert.IsNotNull(boss);
        }

        [Test]
        public void VerifyGroupChiefSpacing()
        {
            // Titles like "GroupChief Digital Officer" should have a space between group + chief.
            MoqUtil.SetupRandMock(2, 1, 16, 5);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Group Chief Digital Officer ", boss);

            Assert.IsNotNull(boss);
        }

        [Test]
        public void VerifyGlobalChiefSpacing()
        {
            // Titles like "GlobalChief Digital Officer" should have a space between global + chief.
            MoqUtil.SetupRandMock(2, 2, 16, 5);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Global Chief Digital Officer ", boss);

            Assert.IsNotNull(boss);
        }

        [Test]
        public void FixExtraSpace()
        {
            List<int> defaults = new List<int> { 14, 51, 1, 2, 1, 3, 277, 82, 11, 21, 2, 82, 2, 7, 10, 1, 8, 3, 2, 250, 61, 4 };
            // This sentence contains a couple of double spaces
            // "an efficient , constructive,  targets the enablers using our constructive, strategic, "
            // 1. Fix the space between "efficient" and the comma.
            // 2. Fix the space between the comma and "targets".
            // 3. See why the sentence ends at strategic.
            // I think 2 and 3 are related to the fact that GetInner and GetSingularAtom only have 
            // a small number of possible selections listed but have huge random number ranges.
            // This means that the app is often selecting 41 as a value with only 1-3 producing 
            // output.
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("efficient,"));
            Assert.IsTrue(output.Contains(" targets "));
        }

        [Test]
        public void FixPluralSpace()
        {
            // This sentence has a few more spaces as well as an odd plural space after timeline.
            //win-win solution  and timeline  24/7 interact with our cost-effective, strategic, timeline sthroughout the organisation
            List<int> defaults = new List<int> {16, 95, 173, 7, 159, 5, 6, 2, 29, 2, 3, 9, 2, 105, 5, 4, 7};

            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("timelines throughout"));
        }

        [Test]
        public void EnsureDeEscalationSpacing()
        {
            // This sentence contains "de-escalations  consistently"
            List<int> defaults = new List<int> { 23, 34, 2, 6, 4, 32, 2, 4, 8, 4, 10, 119, 9, 3, 9, 58, 2, 7, 1, 5, 179, 11, 11, 22, 1, 80, 1, 16, 2, 1, 17, 6 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("de-escalations consistently"));
        }

        [Test]
        public void FixSpaceAtEnd()
        {
            List<int> defaults = new List<int> { 6, 26, 1, 2, 13, 95, 2, 4, 1, 4, 8, 203, 1, 2, 10, 2, 4, 6, 9, 50, 11, 8 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("de-escalations."));
        }

        [Test]
        public void FixMissingWord()
        {
            // This sentence is "the significantly think differently across the board."
            // which is missing a word, not sure what.
            List<int> defaults = new List<int> { 5, 43, 1, 15, 4, 16, 8, 1, 9, 3, 1, 1, 1, 1 };
            MoqUtil.SetupRandMock(defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("Chief Human Resources Officer."));
        }
    }
}
