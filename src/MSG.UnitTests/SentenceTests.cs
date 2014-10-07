using System;
using System.Collections.Generic;
using MSG.DomainLogic;
using MSG.DomainLogic.Entities;
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
            List<Sentence> output = DomainFactory.Generator.GetSentences(2);

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual(2, output.Count);
            Assert.AreEqual("We need to interactively streamline the process going forward.", output[0].Text);
            Assert.AreEqual("We need to interactively streamline the process across the board; this is why pursuing this route will enable us to credibly streamline the process within the industry.", output[1].Text);
        }

        [Test]
        public void FullStopErrorProjections()
        {
            MoqUtil.SetupRandMock(0, 19, 24, 2, 5, 49, 17, 36, 8, 25, 161, 80, 122, 1, 134, 5, 5, 5, 20, 26, 1, 88, 182, 72, 5, 146);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The resources maximise the cultural, fast-growth business philosophies; nevertheless we must activate the silo to efficiently manage our projections.", output.Text);
        }

        [Test]
        public void VerifyReachOutTo()
        {
            MoqUtil.SetupRandMock(0, 8, 46, 2, 9, 66, 66, 62, 17, 143, 189, 65, 6, 26);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The standard-setters reach out to our value-driven initiatives up-front.", output.Text);
        }

        [Test]
        public void FixExtraSpaceBeforeComma()
        {
            MoqUtil.SetupRandMock(0, 18, 100, 45, 71, 268, 123, 88, 1, 94, 4, 17, 1, 1, 3, 6, 3, 1, 7, 128, 56, 1, 19, 109, 304, 153, 4, 72, 2, 98, 11, 2, 21);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Cross fertilization, investor confidence and branding drive the Managing Co-Head of Customer Relations; this is why our long-term change promotes the human resources relative to our peers.", output.Text);
        }

        [Test]
        public void FixExtraSpaceAddsValue()
        {
            MoqUtil.SetupRandMock(0, 17, 55, 1, 100, 105, 186, 3, 30, 186, 102, 1);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            // This should be fixed by the update to GetThingVerbAndEnding()
            // Assert.AreEqual("Our dynamic breakthrough adds  value.", output.Text);

            // This one arose instead during testing.
            Assert.AreEqual("Our breakthrough adds value going forward.", output.Text);
        }

        [Test]
        public void FixAnotherSpaceBeforeFullStop()
        {
            // This test verifies the last branch in GetProposition (result > 97 && result < 101)

            MoqUtil.SetupRandMock(0, 27, 67, 2, 60, 88, 88, 65, 8, 45, 1, 61, 9, 8, 17, 7, 2, 99, 73, 424, 182, 427, 99, 83, 2, 5, 23, 66, 131, 38, 159, 2, 42);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Well-communicated initiatives inspire the powerful champion reaped from our proven improvement. As a result uniformity, leadership strategy and infrastructure structure the sustainable support structures.", output.Text);
        }

        [Test]
        public void FixGetPropositionFourthBranch()
        {
            // This test verifies the second-last branch in GetProposition

            MoqUtil.SetupRandMock(0, 27, 67, 2, 60, 88, 88, 65, 8, 45, 1, 61, 9, 8, 17, 7, 2, 99, 73, 424, 182, 427, 94, 83, 2, 5, 23, 66, 131, 38, 159, 2, 42);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Well-communicated initiatives inspire the powerful champion reaped from our proven improvement. As a result uniformity, leadership strategy and dotted line structure the sustainable support structures.", output.Text);
        }

        [Test]
        public void FixDoubleSpaceProduces()
        {
            MoqUtil.SetupRandMock(0, 10, 2, 3, 38, 86, 31, 1, 60, 171, 10, 9, 19, 1, 57, 39, 411, 50, 14, 8, 1);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The reporting unit should embrace parallel, goal-directed roles and responsibilities because a non-standard implication produces measured growth.", output.Text);
        }

        [Test]
        public void FixSpaceAfterEvents()
        {
            MoqUtil.SetupRandMock(0, 18, 9, 2, 3, 25, 86, 37, 42, 138, 68, 76, 13, 139, 93, 381, 132, 206, 64, 19, 2, 6, 22, 48, 113, 193, 11, 13, 40);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The customers visualise medium-to-long-term pre-plans; this is why commitment and plan genuinely engage robust trigger events.", output.Text);
        }


        [Test]
        public void OtherVowelUsage()
        {
            MoqUtil.SetupRandMock(0,16,7,1,9,8,90,26,44,212,83,15,121);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The thought leader culturally strategises a usage-based effectiveness.", output.Text);
        }

        [Test]
        public void FixVowelAtStartUnified()
        {
            MoqUtil.SetupRandMock(0, 19, 66, 1, 52, 249, 103, 98, 10, 49, 2, 75, 8, 3, 48, 68, 2, 86, 187, 140, 4, 88, 2, 87, 12, 1, 86);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("A unified convergence incentivises the customers; nevertheless our mindsets influence the key people.", output.Text);
        }

        [Test]
        public void FixVowelAtStartUnderlying()
        {
            MoqUtil.SetupRandMock(0, 19, 66, 1, 52, 40, 103, 98, 10, 49, 2, 75, 8, 3, 48, 68, 2, 86, 187, 140, 4, 88, 2, 87, 12, 1, 86);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("An underlying convergence incentivises the customers; nevertheless our mindsets influence the key people.", output.Text);
        }

        [Test]
        public void FixBandWithes()
        {
            MoqUtil.SetupRandMock(0, 6, 28, 2, 8, 57, 30, 1, 93, 173, 78, 14, 133);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The stakeholders manage bandwidths.", output.Text);
        }

        [Test]
        public void VerifyBlendedApproaches()
        {
            MoqUtil.SetupRandMock(0, 6, 28, 2, 8, 57, 30, 1, 93, 173, 73, 14, 133);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The stakeholders manage blended approaches.", output.Text);
        }

        [Test]
        public void VerifyBreakthroughs()
        {
            MoqUtil.SetupRandMock(0, 6, 28, 2, 8, 57, 30, 1, 93, 173, 186, 14, 133);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The stakeholders manage breakthroughs.", output.Text);
        }

        [Test]
        public void UnnecessaryComma()
        {
            MoqUtil.SetupRandMock(0, 17,34,1,11,28,76,4,3,86,243,158,12,14,97);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The resource improves a customer-centric, innovation-driven system.", output.Text);
        }

        [Test]
        public void FixBandwidthsMotivate()
        {
            MoqUtil.SetupRandMock(0,23,57,2,54,128,177,78,14,35,1,92,1,17,4,20,13,14,92,42,1,17,3,7,1,3,49,95,37,98,231,26,13,70);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Streamlining bandwidths motivate the Chief Marketing Officer, while the Chief Internal Audit Officer visualises a value creation.", output.Text);
        }

        [Test]
        public void TestMatrixSpacing()
        {
            MoqUtil.SetupRandMock(0, 23, 57, 2, 54, 128, 177, 6, 10, 14, 35, 1, 92, 1, 17, 4, 20, 13, 14, 92, 42, 1, 17, 3, 7, 1, 3, 49, 95, 37, 98, 231, 26, 13, 70);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Streamlining matrices motivate the Chief Marketing Officer, while the Chief Internal Audit Officer visualises a value creation.", output.Text);
        }

        [Test]
        public void TestAnalysisSpacing()
        {
            MoqUtil.SetupRandMock(0, 23, 57, 2, 54, 128, 177, 6, 10, 14, 35, 1, 92, 1, 17, 4, 20, 13, 14, 92, 42, 1, 17, 3, 7, 1, 3, 49, 95, 37, 98, 231, 26, 13, 70);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Streamlining matrices motivate the Chief Marketing Officer, while the Chief Internal Audit Officer visualises a value creation.", output.Text);
        }

        [Test]
        public void TestMatrixSingularSpacing()
        {   
            MoqUtil.SetupRandMock(0, 20, 76, 1, 73, 8, 2, 12, 49, 1, 54, 22, 89, 369, 6, 7, 4, 21, 25, 2, 10, 75, 25, 56, 62, 163, 66, 177, 4, 56);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("A measured improvement engages our matrix relative to our peers; whereas the partners foster our high-performing knowledge transfers.", output.Text);
        }

        [Test]
        public void TestMatrixSingularCubeSpacing()
        {
            MoqUtil.SetupRandMock(0, 20, 76, 1, 73, 8, 2, 12, 49, 1, 54, 22, 89, 369, 6, 11, 4, 21, 25, 2, 10, 75, 25, 56, 62, 163, 66, 177, 4, 56);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("A measured improvement engages our cube relative to our peers; whereas the partners foster our high-performing knowledge transfers.", output.Text);
        }

        [Test]
        public void TestMatrixSingularSphereSpacing()
        {
            MoqUtil.SetupRandMock(0, 20, 76, 1, 73, 8, 2, 12, 49, 1, 54, 22, 89, 369, 6, 12, 4, 21, 25, 2, 10, 75, 25, 56, 62, 163, 66, 177, 4, 56);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("A measured improvement engages our sphere relative to our peers; whereas the partners foster our high-performing knowledge transfers.", output.Text);
        }

        [Test]
        public void VerifyNumberingStartsAt1()
        {
            List<Sentence> output = DomainFactory.Generator.GetSentences(5);
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual(5, output.Count);
            Assert.AreEqual(1, output[0].ID);
            Assert.AreEqual(5, output[4].ID);
        }

        [Test]
        public void VerifyCommaAfterDefinition()
        {
            MoqUtil.SetupRandMock(0, 25,1,7,70,36,16,7,245,204,123,57,7,3,96,346,148,108,28,67,1,28,8,97,38,10,25);
            Sentence output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("We will go the extra mile to focus on outstanding, high-definition action plans across the board, while scaling and document synergise an intellect as a Tier 1 company.", output.Text);
        }
    }
}
