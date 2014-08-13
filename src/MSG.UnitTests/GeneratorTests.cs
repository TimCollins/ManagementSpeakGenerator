using System.Text;
using Moq;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class GeneratorTests
    {
        [Test]
        public void VerifyManagingOutput()
        {
            // Rand == 1 return Managing
            SetupRandMock(1);
            string output = DomainFactory.Generator.Managing();

            UndoMockRandomNumber();

            Assert.AreEqual("Managing ", output);
        }

        [Test]
        public void VerifyManagingOutputAlt()
        {
            // Rand == 2 return Acting
            SetupRandMock(2);
            string output = DomainFactory.Generator.Managing();

            UndoMockRandomNumber();

            Assert.AreEqual("Acting ", output);
        }

        [Test]
        public void VerifyManagingEmptyString()
        {
            // Rand == not 1 or 2 then return empty string.
            SetupRandMock(17);
            string output = DomainFactory.Generator.Managing();

            UndoMockRandomNumber();

            Assert.AreEqual(string.Empty, output);
        }

        [Test]
        public void VerifySpacingInManagingHead()
        {
            StringBuilder boss = new StringBuilder();

            SetupRandMock(1, 2, 3, 3, 12);

            boss.Append(DomainFactory.Generator.Managing());
            boss.Append(DomainFactory.Generator.Age());
            boss.Append(DomainFactory.Generator.Exec());
            boss.Append(DomainFactory.Generator.Title());
            
            UndoMockRandomNumber();

            Assert.AreEqual("Managing Head", boss.ToString());
        }

        [Test]
        public void VerifySpacingInActingHead()
        {
            StringBuilder boss = new StringBuilder();

            SetupRandMock(2, 2, 3, 3, 12);

            boss.Append(DomainFactory.Generator.Managing());
            boss.Append(DomainFactory.Generator.Age());
            boss.Append(DomainFactory.Generator.Exec());
            boss.Append(DomainFactory.Generator.Title());

            UndoMockRandomNumber();

            Assert.AreEqual("Acting Head", boss.ToString());
        }

        [Test]
        public void VerifySpacingInActingSeniorExecutiveHead()
        {
            StringBuilder boss = new StringBuilder();

            SetupRandMock(2, 1, 1, 3, 12);

            boss.Append(DomainFactory.Generator.Managing());
            boss.Append(DomainFactory.Generator.Age());
            boss.Append(DomainFactory.Generator.Exec());
            boss.Append(DomainFactory.Generator.Title());

            UndoMockRandomNumber();

            Assert.AreEqual("Acting Senior Executive Head", boss.ToString());
        }

        [Test]
        public void VerifySpacingInManagingDirector()
        {
            StringBuilder boss = new StringBuilder();

            SetupRandMock(1, 2, 2, 1, 12);

            boss.Append(DomainFactory.Generator.Managing());
            boss.Append(DomainFactory.Generator.Age());
            boss.Append(DomainFactory.Generator.Exec());
            boss.Append(DomainFactory.Generator.Title());

            UndoMockRandomNumber();

            Assert.AreEqual("Managing Director", boss.ToString());
        }

        [Test]
        public void VerifyBoss()
        {
            // The overall Boss function calls the following to form a title so let's get them added:
            //return Managing & Age & Exec & Title & " of " & Department;
            //string boss = DomainFactory.Generator.Managing() + DomainFactory.Generator.Age() +
            //              DomainFactory.Generator.Exec() + DomainFactory.Generator.Title();

            //UndoMockRandomNumber();

            SetupRandMock(1, 2, 1, 1, 3, 12, 12);

            string boss = DomainFactory.Generator.GetBoss();
     
            UndoMockRandomNumber();

            Assert.AreEqual("Acting Senior Executive Head of IT Strategy", boss);

            Assert.IsNotNull(boss);
        }

        [Test]
        public void VerifyPresidentSpacing()
        {
            StringBuilder boss = new StringBuilder();

            SetupRandMock(3, 2, 2, 4, 12);

            boss.Append(DomainFactory.Generator.Managing());
            boss.Append(DomainFactory.Generator.Age());
            boss.Append(DomainFactory.Generator.Exec());
            boss.Append(DomainFactory.Generator.Title());

            UndoMockRandomNumber();

            Assert.AreEqual("President", boss.ToString());
        }

        [Test]
        public void VerifyBossAlt()
        {
            SetupRandMock(2, 1, 17);

            string boss = DomainFactory.Generator.GetBoss();

            UndoMockRandomNumber();

            Assert.AreEqual("Group Chief Technical Officer", boss);

            Assert.IsNotNull(boss);
        }

        [Test]
        public void VerifyChiefSpacing()
        {
            // Titles like " Chief Operations Officer" should not have a space at the start.
            SetupRandMock(2, 3, 14, 5);

            string boss = DomainFactory.Generator.GetBoss();

            UndoMockRandomNumber();

            Assert.AreEqual("Chief Operations Officer", boss);

            Assert.IsNotNull(boss);
        }

        [Test]
        public void VerifyGroupChiefSpacing()
        {
            // Titles like "GroupChief Digital Officer" should have a space between group + chief.
            SetupRandMock(2, 1, 16, 5);

            string boss = DomainFactory.Generator.GetBoss();

            UndoMockRandomNumber();

            Assert.AreEqual("Group Chief Digital Officer", boss);

            Assert.IsNotNull(boss);
        }

        [Test]
        public void VerifyGlobalChiefSpacing()
        {
            // Titles like "GlobalChief Digital Officer" should have a space between global + chief.
            SetupRandMock(2, 2, 16, 5);

            string boss = DomainFactory.Generator.GetBoss();

            UndoMockRandomNumber();

            Assert.AreEqual("Global Chief Digital Officer", boss);

            Assert.IsNotNull(boss);
        }

        private void SetupRandMock(params int[] values)
        {
            Mock<IRandomNumber> mockRand = new Mock<IRandomNumber>();
            mockRand.Setup(m => m.GetRand(It.IsAny<int>(), It.IsAny<int>())).ReturnsInOrder(values);
            DomainFactory.RandomNumber = mockRand.Object;
        }

        private void SetupRandMock(int result)
        {
            Mock<IRandomNumber> mockRand = new Mock<IRandomNumber>();
            mockRand.Setup(m => m.GetRand(It.IsAny<int>(), It.IsAny<int>())).Returns(result);

            DomainFactory.RandomNumber = mockRand.Object;
        }

        private void UndoMockRandomNumber()
        {
            DomainFactory.RandomNumber = null;
        }
    }
}
