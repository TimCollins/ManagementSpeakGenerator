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
            MoqUtil.SetupRandMock(1, 17, 2, 2, 3, 2, 14);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Head of Marketing", boss);
        }

        [Test]
        public void VerifySpacingInManagingHead()
        {
            MoqUtil.SetupRandMock(1, 1, 2, 2, 3, 2, 14);
            
            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Managing Head of Marketing", boss);
        }

        [Test]
        public void VerifySpacingInActingHead()
        {
            MoqUtil.SetupRandMock(1, 2, 2, 2, 3, 2, 5);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Acting Head of Operations", boss);
        }

        [Test]
        public void VerifyDirectorTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 1, 17, 4);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Director of Legal", boss);
        }

        [Test]
        public void VerifyChiefTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 2, 7);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Chief of Customer Relations", boss);
        }

        [Test]
        public void VerifyHeadTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 3, 17, 4);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Head of Legal", boss);
        }

        [Test]
        public void VerifyCoHeadTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 3, 1, 5);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Co-Head of Operations", boss);
        }

        [Test]
        public void VerifyPresidentTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 4, 17, 7);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("President of Customer Relations", boss);
        }

        [Test]
        public void VerifyVicePresidentTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 4, 8, 14);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Vice President of Marketing", boss);
        }

        [Test]
        public void VerifyCorporateVicePresidentTitle()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 4, 11, 13);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Corporate Vice President of IT Operations", boss);
        }

        [Test]
        public void VerifySeniorAge()
        {
            MoqUtil.SetupRandMock(1, 3, 1, 2, 4, 8, 7);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Senior Vice President of Customer Relations", boss);
        }

        [Test]
        public void VerifyNoSeniorAge()
        {
            MoqUtil.SetupRandMock(1, 3, 1, 2, 4, 8, 14);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Senior Vice President of Marketing", boss);
        }

        [Test]
        public void VerifySeniorExecutive()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 1, 2, 7);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Executive Chief of Customer Relations", boss);
        }

        [Test]
        public void VerifyNoSeniorExecutive()
        {
            MoqUtil.SetupRandMock(1, 3, 2, 2, 2, 4);

            string boss = DomainFactory.Generator.GetBoss();
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Chief of Legal", boss);
        }

        //[Test]
        //public void VerifySpacingInActingSeniorExecutiveHead()
        //{
        //    StringBuilder boss = new StringBuilder();

        //    MoqUtil.SetupRandMock(2, 1, 1, 3, 12);

        //    boss.Append(DomainFactory.Generator.Managing());
        //    boss.Append(DomainFactory.Generator.Age());
        //    boss.Append(DomainFactory.Generator.Exec());
        //    boss.Append(DomainFactory.Generator.Title());

        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.AreEqual("Acting Senior Executive Head", boss.ToString());
        //}

        //[Test]
        //public void VerifySpacingInManagingDirector()
        //{
        //    StringBuilder boss = new StringBuilder();

        //    MoqUtil.SetupRandMock(1, 2, 2, 1, 12);

        //    boss.Append(DomainFactory.Generator.Managing());
        //    boss.Append(DomainFactory.Generator.Age());
        //    boss.Append(DomainFactory.Generator.Exec());
        //    boss.Append(DomainFactory.Generator.Title());

        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.AreEqual("Managing Director", boss.ToString());
        //}

        [Test]
        public void VerifyBoss()
        {
            MoqUtil.SetupRandMock(1, 2, 1, 1, 3, 12, 12);

            string boss = DomainFactory.Generator.GetBoss();

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Acting Senior Executive Head of IT Strategy", boss);

            Assert.IsNotNull(boss);
        }

        //[Test]
        //public void VerifyPresidentSpacing()
        //{
        //    StringBuilder boss = new StringBuilder();

        //    MoqUtil.SetupRandMock(3, 2, 2, 4, 12);

        //    boss.Append(DomainFactory.Generator.Managing());
        //    boss.Append(DomainFactory.Generator.Age());
        //    boss.Append(DomainFactory.Generator.Exec());
        //    boss.Append(DomainFactory.Generator.Title());

        //    MoqUtil.UndoMockRandomNumber();

        //    Assert.AreEqual("President", boss.ToString());
        //}

        [Test]
        public void VerifyBossAlt()
        {
            MoqUtil.SetupRandMock(2, 1, 17);

            string boss = DomainFactory.Generator.GetBoss();

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Group Chief Technical Officer", boss);

            Assert.IsNotNull(boss);
        }

        [Test]
        public void VerifyChiefSpacing()
        {
            // Titles like " Chief Operations Officer" should not have a space at the start.
            MoqUtil.SetupRandMock(2, 3, 14, 5);

            string boss = DomainFactory.Generator.GetBoss();

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Chief Operations Officer", boss);

            Assert.IsNotNull(boss);
        }

        [Test]
        public void VerifyGroupChiefSpacing()
        {
            // Titles like "GroupChief Digital Officer" should have a space between group + chief.
            MoqUtil.SetupRandMock(2, 1, 16, 5);

            string boss = DomainFactory.Generator.GetBoss();

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Group Chief Digital Officer", boss);

            Assert.IsNotNull(boss);
        }

        [Test]
        public void VerifyGlobalChiefSpacing()
        {
            // Titles like "GlobalChief Digital Officer" should have a space between global + chief.
            MoqUtil.SetupRandMock(2, 2, 16, 5);

            string boss = DomainFactory.Generator.GetBoss();

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Global Chief Digital Officer", boss);

            Assert.IsNotNull(boss);
        }
    }
}
