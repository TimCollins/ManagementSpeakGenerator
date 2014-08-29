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
            // Insert 1 at position 6.
            _defaults.Insert(6, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            
            Assert.IsTrue(output.Contains("streamline the process "));
        }

        [Test]
        public void VerifyPersonVerbAndComplementOverarching()
        {
            _defaults.Insert(6, 2);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("address the overarching issues "));
        }

        [Test]
        public void VerifyPersonVerbAndComplementValueChain()
        {
            _defaults.Insert(6, 10);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("think across the full value chain "));
        }

        [Test]
        public void VerifyBadThingIdentify()
        {
            _defaults.Insert(5, 11);
            _defaults.RemoveAt(6);

            _defaults.Insert(6, 2);
            _defaults.RemoveAt(7);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("identify"));
        }

        [Test]
        public void VerifyBadThingMitigate()
        {
            _defaults.Insert(5, 11);
            _defaults.RemoveAt(6);

            _defaults.Insert(6, 4);
            _defaults.RemoveAt(7);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("mitigate"));
        }
        
        [Test]
        public void VerifyRandomArticleThe()
        {
            _defaults.Insert(5, 11);
            _defaults.RemoveAt(6);

            _defaults.Insert(6, 4);
            _defaults.RemoveAt(7);

            _defaults.Insert(9, 2);
            _defaults.RemoveAt(10);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("the issues"));
        }

        [Test]
        public void VerifyRandomArticleOur()
        {
            // Within the industry
            //_defaults.Insert(9, 2);
            //_defaults.RemoveAt(10);

            // going forward
            //_defaults.Insert(8, 2);
            //_defaults.RemoveAt(9);

            // intricacies
            //_defaults.Insert(7, 2);
            //_defaults.RemoveAt(8);

            //_defaults.Insert(5, 2);
            //_defaults.RemoveAt(6);

            _defaults.Insert(5, 11);
            _defaults.RemoveAt(6);

            _defaults.Insert(6, 4);
            _defaults.RemoveAt(7);

            _defaults.Insert(8, 3);
            _defaults.RemoveAt(9);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("our issues"));
        }

        [Test]
        public void VerifyGetPersonVerbAndEndingThirdBranch()
        {
            _defaults.Insert(5, 17);
            _defaults.RemoveAt(6);

            _defaults.Insert(6, 4);
            _defaults.RemoveAt(7);
            
            _defaults.Insert(8, 3);
            _defaults.RemoveAt(9);

            _defaults.Add(2);
            _defaults.Add(2);
            _defaults.Add(3);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("across the board"));
        }
    }
}
