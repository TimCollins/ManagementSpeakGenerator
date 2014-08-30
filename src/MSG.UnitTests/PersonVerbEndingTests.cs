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
            _defaults = new List<int> { 17, 5, 9, 8, 1, 1, 1, 1, 1, 1 };
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyPersonVerbAndComplementStreamline()
        {
            _defaults.Insert(5, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            
            Assert.IsTrue(output.Contains("streamline the process "));
        }

        [Test]
        public void VerifyPersonVerbAndComplementOverarching()
        {
            _defaults.Insert(5, 2);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("address the overarching issues "));
        }

        [Test]
        public void VerifyPersonVerbAndComplementValueChain()
        {
            _defaults.Insert(5, 10);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("think across the full value chain "));
        }

        [Test]
        public void VerifyBadThingIdentify()
        {
            _defaults.ReplaceAt(4, 11);
            _defaults.ReplaceAt(5, 2);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("identify"));
        }

        [Test]
        public void VerifyBadThingMitigate()
        {
            _defaults.ReplaceAt(4, 11);
            _defaults.ReplaceAt(5, 4);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("mitigate"));
        }
        
        [Test]
        public void VerifyRandomArticleThe()
        {
            _defaults.ReplaceAt(4, 11);
            _defaults.ReplaceAt(5, 4);
            _defaults.ReplaceAt(8, 2);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("the issues"));
        }

        [Test]
        public void VerifyRandomArticleOur()
        {
            _defaults.ReplaceAt(4, 11);
            _defaults.ReplaceAt(5, 4);
            _defaults.ReplaceAt(7, 3);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("our issues"));
        }

        [Test]
        public void VerifyGetPersonVerbAndEndingThirdBranch()
        {
            _defaults.ReplaceAt(4, 17);
            _defaults.ReplaceAt(5, 4);
            _defaults.ReplaceAt(7, 3);

            _defaults.Add(2);
            _defaults.Add(3);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("across the board"));
        }
    }
}
