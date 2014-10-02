using System.Collections.Generic;
using MSG.DomainLogic;
using MSG.DomainLogic.Entities;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class GetThingTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> {0, 10, 55, 1, 14, 9, 22, 2, 5, 1, 25, 28, 5, 15, 10, 23, 6, 1};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void GetThingFirstBranch()
        {
            _defaults.Insert(4, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The holistic, cost-effective leverage 200% enforces our new, focused diversification going forward.", output.Text);
        }

        [Test]
        public void GetThingSecondBranch()
        {
            _defaults.Insert(4, 13);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The holistic and cost-effective leverage 200% enforces our new, focused diversification going forward.", output.Text);
        }

        [Test]
        public void GetThingThirdBranch()
        {
            _defaults.Insert(4, 50);
            _defaults.ReplaceAt(16, 2);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("A holistic governance credibly accelerates strong mobile strategies within the industry.", output.Text);
        }

        [Test]
        public void GetThingFourthBranch()
        {
            _defaults.Insert(4, 72);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The holistic and/or cost-effective leverage 200% enforces our new, focused diversification going forward.", output.Text);
        }

        [Test]
        public void GetThingFifthBranch()
        {
            _defaults.Insert(4, 74);
            _defaults.ReplaceAt(5, 2);
            _defaults.ReplaceAt(6, 4);
            _defaults.ReplaceAt(16, 6);
            _defaults.Add(2);
            _defaults.Add(3);
            _defaults.Add(4);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("A double-digit efficiency gain credibly accelerates strong mobile strategies at the end of the day.", output.Text);
        }

        [Test]
        public void GetThingSixthBranch()
        {
            _defaults.Insert(4, 78);
            _defaults.Add(2);
            _defaults.Add(3);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("Our holistic, cost-effective and non-linear team building interactively impacts the focused organisations across the board.", output.Text);
        }

        [Test]
        public void GetThingSeventhBranch()
        {
            _defaults.Insert(4, 84);
            _defaults.Add(2);
            _defaults.Add(3);
            
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The holistic, cost-effective, non-linear and strategic planning granularity results in the problem-solving and key key target markets across the board.", output.Text);
        }
    }
}
