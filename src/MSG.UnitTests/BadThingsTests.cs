﻿using System.Collections.Generic;
using MSG.DomainLogic;
using MSG.DomainLogic.Entities;
using NUnit.Framework;

namespace MSG.UnitTests
{
    /// <summary>
    /// Unit tests that verify the expected output from the GetBadThings() method.
    /// </summary>
    [TestFixture]
    class BadThingsTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> {0, 17, 8, 2, 8, 6, 11, 3, 5, 12, 8};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyExceptionThrownForInvalidInput()
        {
            _defaults.ReplaceAt(4, 50);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Assert.Throws<RandomNumberException>(() => DomainFactory.Generator.GetSentences(1));
        }

        [Test]
        public void VerifyIssuesOutput()
        {
            _defaults.ReplaceAt(8, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The stakeholders 24/7 avoid issues as part of the plan.", output.Text);
        }

        [Test]
        public void VerifyKnownUnknowns()
        {
            _defaults.ReplaceAt(2, 2);
            _defaults.RemoveAt(3);
            _defaults.ReplaceAt(7, 8);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We are working hard to 24/7 avoid known unknowns as part of the plan.", output.Text);
        }

        [Test]
        public void VerifySurprises()
        {
            _defaults.ReplaceAt(2, 3);
            _defaults.RemoveAt(3);
            _defaults.ReplaceAt(7, 12);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We are working hard to 24/7 avoid surprises as part of the plan.", output.Text);
        }

        [Test]
        public void VerifyProblems()
        {
            _defaults.ReplaceAt(8, 18);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The stakeholders 24/7 avoid problems as part of the plan.", output.Text);
        }

        [Test]
        public void VerifyConsumer()
        {
            _defaults.ReplaceAt(8, 21);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Sentence output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The stakeholders 24/7 avoid consumer/agent disconnects as part of the plan.", output.Text);
        }
    }
}
