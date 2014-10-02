using System.Collections.Generic;
using MSG.DomainLogic;
using MSG.DomainLogic.Entities;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class ArticulatedPropositionTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int>{0, 5, 9, 10, 1, 1, 1, 1,
                                         5, 9, 10, 1, 1, 1, 1};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyArticulatedProposition()
        {
            _defaults.Insert(1, 6);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward.", output.Text);
        }

        [Test]
        public void VerifyArticulatedPropositionIsWhy()
        {
            _defaults.Insert(1, 18);
            _defaults.Insert(3, 7);
            _defaults.Remove(3);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We will go the extra mile to technically streamline the process going forward; this is why we need to 200% think across the full value chain going forward.", output.Text);
        }

        [Test]
        public void VerifyArticulatedPropositionNevertheless()
        {
            _defaults.Insert(1, 19);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward; nevertheless we must activate the matrix to strategically streamline the process going forward.", output.Text);
        }

        [Test]
        public void VerifyArticulatedPropositionWhereas()
        {
            _defaults.Insert(1, 20);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward; whereas we must activate the matrix to strategically streamline the process going forward.", output.Text);
        }

        [Test]
        public void VerifyArticulatedPropositionGutFeeling()
        {
            _defaults.Insert(1, 21);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("Our gut feeling is that we continue to work tirelessly and diligently to strategically streamline the process going forward.", output.Text);
        }

        [Test]
        public void VerifyArticulatedPropositionWhile()
        {
            _defaults.Insert(1, 25);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward, while we must activate the matrix to strategically streamline the process going forward.", output.Text);
        }

        [Test]
        public void VerifyArticulatedPropositionSameTime()
        {
            _defaults.Insert(1, 26);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward. At the same time, we must activate the matrix to strategically streamline the process going forward.", output.Text);
        }

        [Test]
        public void VerifyArticulatedPropositionResult()
        {
            _defaults.Insert(1, 27);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward. As a result we must activate the matrix to strategically streamline the process going forward.", output.Text);
        }

        [Test]
        public void VerifyArticulatedPropositionWhilst()
        {
            _defaults.Insert(1, 28);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward, whilst we must activate the matrix to strategically streamline the process going forward.", output.Text);
        }

        [Test]
        public void VerifyExceptionThrown()
        {
            _defaults.Insert(1, 555);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Assert.Throws<RandomNumberException>(() => DomainFactory.Generator.GetSentences(1));
        }
    }
}
