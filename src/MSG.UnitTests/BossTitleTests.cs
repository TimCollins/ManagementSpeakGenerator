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

        [Test]
        public void VerifySeniorAge()
        {
            _defaults.ReplaceAt(6, 1);
            _defaults.ReplaceAt(8, 4);
            _defaults.Insert(9, 6);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            Assert.AreEqual("The Senior Vice President of Marketing culturally exceeds expectations at the individual, team and organizational level.", output);
        }

        [Test]
        public void VerifySeniorExecutive()
        {
            _defaults.ReplaceAt(7, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            Assert.AreEqual("The Executive Chief of Marketing culturally exceeds expectations at the individual, team and organizational level.", output);
        }

        [Test]
        public void VerifyDepartment()
        {
            _defaults.ReplaceAt(5, 2);
            _defaults.ReplaceAt(8, 3);
            _defaults.Insert(9, 4);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            Assert.AreEqual("The Acting Head of Marketing culturally exceeds expectations at the individual, team and organizational level.", output);
        }

        [Test]
        public void VerifySpacingInActingSeniorExecutiveHead()
        {
            _defaults.ReplaceAt(5, 2);
            _defaults.ReplaceAt(6, 1);
            _defaults.ReplaceAt(7, 1);
            _defaults.ReplaceAt(8, 3);
            _defaults.Insert(9, 4);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            Assert.AreEqual("The Acting Senior Executive Head of Marketing culturally exceeds expectations at the individual, team and organizational level.", output);
        }

        [Test]
        public void VerifySpacingInManagingDirector()
        {
            _defaults.ReplaceAt(5, 1);
            _defaults.ReplaceAt(6, 4);
            _defaults.ReplaceAt(8, 1);
            _defaults.Insert(10, 14);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            Assert.AreEqual("The Managing Director of Marketing culturally exceeds expectations at the individual, team and organizational level.", output);
        }        

        [Test]
        public void VerifyBossAlt()
        {
            _defaults.ReplaceAt(4, 2);
            _defaults.ReplaceAt(5, 1);
            _defaults.ReplaceAt(6, 17);
            _defaults.RemoveAt(8);
            _defaults.RemoveAt(9);
            _defaults.ReplaceAt(9, 3);
            _defaults.Add(8);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            Assert.AreEqual("The Group Chief Technical Officer quickly avoids uncertainties as part of the plan.", output);
        }

        [Test]
        public void VerifyChiefSpacing()
        {
            _defaults.ReplaceAt(4, 2);
            _defaults.ReplaceAt(7, 5);
            _defaults.ReplaceAt(10, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            Assert.AreEqual("The Chief Operations Officer credibly addresses unknown unknowns at the individual, team and organizational level.", output);
        }

        //_defaults = new List<int> {1, 7, 1, 17, 1, 5, 6, 3, 2, 14, 8, 9, 19, 33};

        [Test]
        public void VerifyGroupChiefSpacing()
        {
            _defaults.ReplaceAt(4, 2);
            _defaults.ReplaceAt(5, 1);
            _defaults.ReplaceAt(6, 16);
            _defaults.ReplaceAt(7, 5);
            _defaults.ReplaceAt(10, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            Assert.AreEqual("The Group Chief Digital Officer 200% achieves efficiencies going forward.", output);
        }

        [Test]
        public void VerifyGlobalChiefSpacing()
        {
            _defaults.ReplaceAt(4, 2);
            _defaults.ReplaceAt(5, 2);
            _defaults.ReplaceAt(6, 16);
            _defaults.ReplaceAt(7, 5);
            _defaults.ReplaceAt(10, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            Assert.AreEqual("The Global Chief Digital Officer 200% achieves efficiencies going forward.", output);
        }
    }
}
