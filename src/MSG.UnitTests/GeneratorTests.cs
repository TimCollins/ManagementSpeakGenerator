﻿using System.Text;
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
            MoqUtil.SetupRandMock(1);
            string output = DomainFactory.Generator.Managing();

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Managing ", output);
        }

        [Test]
        public void VerifyManagingOutputAlt()
        {
            // Rand == 2 return Acting
            MoqUtil.SetupRandMock(2);
            string output = DomainFactory.Generator.Managing();

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Acting ", output);
        }

        [Test]
        public void VerifyManagingEmptyString()
        {
            // Rand == not 1 or 2 then return empty string.
            MoqUtil.SetupRandMock(17);
            string output = DomainFactory.Generator.Managing();

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual(string.Empty, output);
        }

        [Test]
        public void VerifySpacingInManagingHead()
        {
            StringBuilder boss = new StringBuilder();

            MoqUtil.SetupRandMock(1, 2, 3, 3, 12);

            boss.Append(DomainFactory.Generator.Managing());
            boss.Append(DomainFactory.Generator.Age());
            boss.Append(DomainFactory.Generator.Exec());
            boss.Append(DomainFactory.Generator.Title());

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Managing Head", boss.ToString());
        }

        [Test]
        public void VerifySpacingInActingHead()
        {
            StringBuilder boss = new StringBuilder();

            MoqUtil.SetupRandMock(2, 2, 3, 3, 12);

            boss.Append(DomainFactory.Generator.Managing());
            boss.Append(DomainFactory.Generator.Age());
            boss.Append(DomainFactory.Generator.Exec());
            boss.Append(DomainFactory.Generator.Title());

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Acting Head", boss.ToString());
        }

        [Test]
        public void VerifySpacingInActingSeniorExecutiveHead()
        {
            StringBuilder boss = new StringBuilder();

            MoqUtil.SetupRandMock(2, 1, 1, 3, 12);

            boss.Append(DomainFactory.Generator.Managing());
            boss.Append(DomainFactory.Generator.Age());
            boss.Append(DomainFactory.Generator.Exec());
            boss.Append(DomainFactory.Generator.Title());

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Acting Senior Executive Head", boss.ToString());
        }

        [Test]
        public void VerifySpacingInManagingDirector()
        {
            StringBuilder boss = new StringBuilder();

            MoqUtil.SetupRandMock(1, 2, 2, 1, 12);

            boss.Append(DomainFactory.Generator.Managing());
            boss.Append(DomainFactory.Generator.Age());
            boss.Append(DomainFactory.Generator.Exec());
            boss.Append(DomainFactory.Generator.Title());

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Managing Director", boss.ToString());
        }

        [Test]
        public void VerifyBoss()
        {
            MoqUtil.SetupRandMock(1, 2, 1, 1, 3, 12, 12);

            string boss = DomainFactory.Generator.GetBoss();

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Acting Senior Executive Head of IT Strategy", boss);

            Assert.IsNotNull(boss);
        }

        [Test]
        public void VerifyPresidentSpacing()
        {
            StringBuilder boss = new StringBuilder();

            MoqUtil.SetupRandMock(3, 2, 2, 4, 12);

            boss.Append(DomainFactory.Generator.Managing());
            boss.Append(DomainFactory.Generator.Age());
            boss.Append(DomainFactory.Generator.Exec());
            boss.Append(DomainFactory.Generator.Title());

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("President", boss.ToString());
        }

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