using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class BossTitleTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> {1, 7, 1, 17, 1, 5, 6, 3, 2, 14, 8, 9, 19, 33};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyBlankManaging()
        {
            _defaults.Insert(5, 4);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            // TODO: Fix the two issues that have arisen in this one:
            //MoqUtil.SetupRandMock(1, 7, 1, 17, 1, 4, 5, 6, 3, 2, 14, 8, 9, 2, 33);
            // 1: address should be addresses
            // 2: issueses shouldn't be pluralised.
            Assert.AreEqual("The Head of Marketing culturally exceeds expectations at the individual, team and organizational level.", output);
        }

        [Test]
        public void VerifySpacingInManagingHead()
        {
            _defaults.Insert(5, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The Managing Head of Marketing culturally exceeds expectations at the individual, team and organizational level.", output);
        }

        [Test]
        public void VerifySpacingInActingHead()
        {
            _defaults.Insert(5, 2);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The Acting Head of Marketing culturally exceeds expectations at the individual, team and organizational level.", output);
        }

        [Test]
        public void VerifyDirectorTitle()
        {
            _defaults.ReplaceAt(6, 4);
            _defaults.ReplaceAt(7, 2);
            _defaults.Insert(8, 1);
            _defaults.ReplaceAt(9, 12);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The Director of Marketing culturally exceeds expectations at the individual, team and organizational level.", output);
        }

        [Test]
        public void VerifyChiefTitle()
        {
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            Assert.AreEqual("The Chief of Marketing culturally exceeds expectations at the individual, team and organizational level.", output);
        }

        [Test]
        public void VerifyHeadTitle()
        {
            _defaults.Insert(5, 4);
            _defaults.ReplaceAt(10, 4);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The Head of Legal culturally exceeds expectations at the individual, team and organizational level.", output);
        }

        [Test]
        public void VerifyCoHeadTitle()
        {
            _defaults.ReplaceAt(8, 3);
            _defaults.Insert(9, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            Assert.AreEqual("The Co-Head of Marketing culturally exceeds expectations at the individual, team and organizational level.", output);
        }

        [Test]
        public void VerifyPresidentTitle()
        {
            _defaults.ReplaceAt(8, 4);
            _defaults.Insert(9, 12);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            Assert.AreEqual("The President of Marketing culturally exceeds expectations at the individual, team and organizational level.", output);
        }

        [Test]
        public void VerifyVicePresidentTitle()
        {
            _defaults.ReplaceAt(8, 4);
            _defaults.Insert(9, 6);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            Assert.AreEqual("The Vice President of Marketing culturally exceeds expectations at the individual, team and organizational level.", output);
        }

        [Test]
        public void VerifyCorporateVicePresidentTitle()
        {
            _defaults.ReplaceAt(8, 4);
            _defaults.Insert(9, 11);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            Assert.AreEqual("The Corporate Vice President of Marketing culturally exceeds expectations at the individual, team and organizational level.", output);
        }

        //[Test]
        //public void VerifySeniorAge()
        //{
        //    MoqUtil.SetupRandMock(1, 3, 1, 2, 4, 8, 7);

        //    string boss = DomainFactory.Generator.GetBoss();
        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.AreEqual("Senior Vice President of Customer Relations ", boss);
        //}

        //[Test]
        //public void VerifyNoSeniorAge()
        //{
        //    MoqUtil.SetupRandMock(1, 3, 1, 2, 4, 8, 14);

        //    string boss = DomainFactory.Generator.GetBoss();
        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.AreEqual("Senior Vice President of Marketing ", boss);
        //}

        //[Test]
        //public void VerifySeniorExecutive()
        //{
        //    MoqUtil.SetupRandMock(1, 3, 2, 1, 2, 7);

        //    string boss = DomainFactory.Generator.GetBoss();
        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.AreEqual("Executive Chief of Customer Relations ", boss);
        //}

        //[Test]
        //public void VerifyNoSeniorExecutive()
        //{
        //    MoqUtil.SetupRandMock(1, 3, 2, 2, 2, 4);

        //    string boss = DomainFactory.Generator.GetBoss();
        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.AreEqual("Chief of Legal ", boss);
        //}

        //[Test]
        //public void VerifyDepartment()
        //{
        //    MoqUtil.SetupRandMock(1, 2, 2, 2, 3, 2, 9);

        //    string boss = DomainFactory.Generator.GetBoss();
        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.AreEqual("Acting Head of Client Relationship ", boss);
        //}

        //[Test]
        //public void VerifySpacingInActingSeniorExecutiveHead()
        //{
        //    MoqUtil.SetupRandMock(1, 2, 1, 1, 3, 2, 12);

        //    string boss = DomainFactory.Generator.GetBoss();
        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.AreEqual("Acting Senior Executive Head of IT Strategy ", boss);
        //}

        //[Test]
        //public void VerifySpacingInManagingDirector()
        //{
        //    MoqUtil.SetupRandMock(1, 1, 2, 2, 1, 12, 10);

        //    string boss = DomainFactory.Generator.GetBoss();
        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.AreEqual("Managing Director of Business Planning ", boss);
        //}

        //[Test]
        //public void VerifyBoss()
        //{
        //    MoqUtil.SetupRandMock(1, 2, 1, 1, 3, 12, 12);

        //    string boss = DomainFactory.Generator.GetBoss();

        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.IsNotNull(boss);
        //    Assert.AreEqual("Acting Senior Executive Head of IT Strategy ", boss);
        //}

        //[Test]
        //public void VerifyBossAlt()
        //{
        //    MoqUtil.SetupRandMock(2, 1, 17);

        //    string boss = DomainFactory.Generator.GetBoss();
        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.IsNotNull(boss);
        //    Assert.AreEqual("Group Chief Technical Officer ", boss);
        //}

        //[Test]
        //public void VerifyChiefSpacing()
        //{
        //    MoqUtil.SetupRandMock(2, 3, 14, 5);

        //    string boss = DomainFactory.Generator.GetBoss();
        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.IsNotNull(boss);
        //    Assert.AreEqual("Chief Operations Officer ", boss);
        //}

        //[Test]
        //public void VerifyGroupChiefSpacing()
        //{
        //    MoqUtil.SetupRandMock(2, 1, 16, 5);

        //    string boss = DomainFactory.Generator.GetBoss();
        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.IsNotNull(boss);
        //    Assert.AreEqual("Group Chief Digital Officer ", boss);
        //}

        //[Test]
        //public void VerifyGlobalChiefSpacing()
        //{
        //    MoqUtil.SetupRandMock(2, 2, 16, 5);

        //    string boss = DomainFactory.Generator.GetBoss();
        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.IsNotNull(boss);
        //    Assert.AreEqual("Global Chief Digital Officer ", boss);
        //}

    }
}
