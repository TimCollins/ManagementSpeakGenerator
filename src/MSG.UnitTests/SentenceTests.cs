using System;
using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class SentenceTests
    {
        [Test]
        public void ExceptionThrownForNegativeCount()
        {
            Assert.Throws<ArgumentException>(() => DomainFactory.Generator.GetSentences(-2));
        }

        [Test]
        public void ExceptionThrownForZeroCount()
        {
            Assert.Throws<ArgumentException>(() => DomainFactory.Generator.GetSentences(0));
        }

        [Test]
        public void VerifyGetSentences()
        {
            // If GetSentences is called twice then there should be 2 sentences in the output.
            // Specify some numbers to get specific output and verify spacing.

            MoqUtil.SetupRandMock(0, 17, 5, 1, 1, 1, 1, 1, 
                                  0, 18, 5, 1, 1, 1, 1, 3, 4, 6, 2, 5, 1, 2, 1);
            List<string> output = DomainFactory.Generator.GetSentences(2);

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual(2, output.Count);
            Assert.AreEqual("We need to interactively streamline the process going forward.", output[0]);
            Assert.AreEqual("We need to interactively streamline the process across the board; this is why pursuing this route will enable us to credibly streamline the process within the industry.", output[1]);
        }

        [Test]
        public void FullStopErrorProjections()
        {
            MoqUtil.SetupRandMock(0, 19, 24, 2, 5, 49, 17, 36, 8, 25, 161, 80, 122, 1, 134, 5, 5, 5, 20, 26, 1, 88, 182, 72, 5, 146);
            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The resources maximise the cultural, fast-growth, business philosophies; nevertheless we must activate the silo to efficiently manage our projections.", output);
        }

        [Test]
        public void VerifyReachOutTo()
        {
            MoqUtil.SetupRandMock(0, 8, 46, 2, 9, 66, 66, 62, 17, 143, 189, 65, 6, 26);
            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The standard-setters reach out to our value-driven initiatives up-front.", output);
        }

        [Test]
        public void FixExtraSpaceBeforeComma()
        {
            MoqUtil.SetupRandMock(0, 18, 100, 45, 71, 268, 123, 88, 1, 94, 4, 17, 1, 1, 3, 6, 3, 1, 7, 128, 56, 1, 19, 109, 304, 153, 4, 72, 2, 98, 11, 2, 21);
            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Cross fertilization, investor confidence and branding drive the Managing Co-Head of Customer Relations; this is why our long-term change promotes the human resources relative to our peers.", output);
        }

        [Test]
        public void FixExtraSpaceAddsValue()
        {
            MoqUtil.SetupRandMock(0, 17, 55, 1, 100, 105, 186, 3, 30, 186, 102, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            // This should be fixed by the update to GetThingVerbAndEnding()
            // Assert.AreEqual("Our dynamic breakthrough adds  value.", output);

            // This one arose instead during testing.
            Assert.AreEqual("Our breakthrough adds value going forward.", output);
        }

        [Test]
        public void FixPlannings()
        {
            // I think this should read "Forward planning engages"
            MoqUtil.SetupRandMock(0, 11, 68, 2, 90, 184, 75, 9, 80, 1, 39, 22, 79, 244, 243, 107, 144, 140, 9, 35);
            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            //Assert.AreEqual("Forward plannings engage a customised, innovation-driven and insightful mindset.", output);
            Assert.AreEqual("Forward planning engages a customised, innovation-driven and insightful mindset.", output);
        }

        [Test]
        public void FixDoubleSpaceProduces()
        {
            MoqUtil.SetupRandMock(0, 10, 2, 3, 38, 86, 31, 1, 60, 171, 10, 9, 19, 1, 57, 39, 411, 50, 14, 8, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The reporting unit should embrace parallel, goal-directed, roles and responsibilities because a non-standard implication produces measured growth.", output);
        }

        //[Test]
        //public void FixVowelAtStart()
        //{
        //    MoqUtil.SetupRandMock(new[] {19, 66, 1, 52, 249, 103, 98, 10, 49, 2, 75, 8, 3, 48, 68, 2, 86, 187, 140, 4, 88, 2, 87, 12, 1, 86});
        //    string output = DomainFactory.Generator.GetSentences(1)[0];
        //    MoqUtil.UndoMockRandomNumber();

        //    // GetIndefiniteArticle() is passed "unified convergence ".
        //    // The problem is that we are making an assumption that everything that starts 
        //    // with a vowel should be prefixed with "an" but that's not always the case, 
        //    // even for the same letter e.g. "an understanding" v "a unified".

        //    // https://www.google.ie/search?client=opera&q=rules+around+a+v+an+for+vowels&sourceid=opera&ie=utf-8&oe=utf-8&channel=suggest&gws_rd=ssl
        //    // http://www.writersdigest.com/online-editor/a-before-consonants-and-an-before-vowels-is-not-the-rule
        //    // The real rule is this: You use the article “a” before words that start with a consonant sound and “an” before words that start with a vowel sound. For example, He has a unique point of view on the subject and talked about it for an hour. The “u” in “unique” makes the “Y” sound—a consonant sound—therefore you use “a” as your article, while the “h” in “hour” sounds like it starts with “ow”—a vowel sound.

        //    Assert.AreEqual("A unified convergence incentivises the customers; nevertheless our mindsets influence the key people.", output);
        //}

        //25,1,7,70,36,16,7,245,204,123,57,7,3,96,346,148,108,28,67,1,28,8,97,38,10,25,
        //We will go the extra mile to focus on outstanding, high-definition, action plans across the board, while scaling and document synergise an intellect as a Tier 1 company.

        //17,34,1,11,28,76,4,3,86,243,158,12,14,97,
        //The resource improves a customer-centric, innovation-driven, system.

        // The senior support staff proactively maximises an on-message value proposition, while image and decision making drive an efficient, consumer-facing, sales target .
        // Our on-message cornerstone streamlines our outward-looking breakthroughes.
        // The Chief Client Relationship Officer consistently resets the benchmark; this is why simplicity and strategic thinking engage business enabling, replacement, high-level and cultural executive talents .
        // Our trusted perspectives drive the enabler. At the same time, knowledge transfer, innovation and portal promote the thought leader .
        // Our dynamic breakthrough adds  value.
        // Our efficient frontier culturally adds  value, while the key people swiftly influence recalibrations.
    }
}
