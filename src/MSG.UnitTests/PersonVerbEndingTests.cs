using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class PersonVerbEndingTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> {0, 17, 5, 9, 8, 1, 1, 1, 1, 1, 1};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyPersonVerbAndComplementStreamline()
        {
            _defaults.Insert(6, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            
            Assert.AreEqual("We continue to work tirelessly and diligently to culturally streamline the process going forward.", output.Text);
        }

        [Test]
        public void VerifyPersonVerbAndComplementOverarching()
        {
            _defaults.Insert(6, 2);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to culturally address the overarching issues going forward.", output.Text);
        }

        [Test]
        public void VerifyPersonVerbAndComplementValueChain()
        {
            _defaults.Insert(6, 10);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to culturally think across the full value chain going forward.", output.Text);
        }

        [Test]
        public void VerifyBadThingIdentify()
        {
            _defaults.ReplaceAt(5, 11);
            _defaults.ReplaceAt(6, 2);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to culturally identify the issues going forward.", output.Text);
        }

        [Test]
        public void VerifyBadThingMitigate()
        {
            _defaults.ReplaceAt(5, 11);
            _defaults.ReplaceAt(6, 4);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to culturally mitigate the issues going forward.", output.Text);
        }
        
        [Test]
        public void VerifyRandomArticleThe()
        {
            _defaults.ReplaceAt(5, 11);
            _defaults.ReplaceAt(6, 4);
            _defaults.ReplaceAt(9, 2);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to culturally mitigate the issues within the industry.", output.Text);
        }

        [Test]
        public void VerifyRandomArticleOur()
        {
            _defaults.ReplaceAt(5, 11);
            _defaults.ReplaceAt(6, 4);
            _defaults.ReplaceAt(8, 3);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to culturally mitigate our issues going forward.", output.Text);
        }

        [Test]
        public void VerifyGetPersonVerbAndEndingThirdBranch()
        {
            _defaults.ReplaceAt(5, 17);
            _defaults.ReplaceAt(6, 4);
            _defaults.ReplaceAt(8, 3);

            _defaults.Add(2);
            _defaults.Add(3);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to culturally improve the constructive, efficient key target markets across the board.", output.Text);
        }

        [Test]
        public void VerifySpacingAddress()
        {
            _defaults.ReplaceAt(5, 11);
            _defaults.ReplaceAt(6, 1);
            _defaults.ReplaceAt(8, 3);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to culturally address our issues going forward.", output.Text);
        }
    }
}
