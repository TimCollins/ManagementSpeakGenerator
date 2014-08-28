using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class SentenceTests
    {
        [Test]
        public void VerifyGetSentences()
        {
            // If GetSentences is called twice then there should be 2 sentences in the output.
            // Specify some numbers to get specific output and verify spacing.

            MoqUtil.SetupRandMock(  17, 5, 1, 1, 1, 1, 1, 1, 
                                    18, 5, 1, 1, 1, 1, 1, 3, 4, 6, 2, 5, 1, 2, 1);
            List<string> output = DomainFactory.Generator.GetSentences(2);

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual(2, output.Count);
            Assert.AreEqual("We need to interactively streamline the process going forward.", output[0]);
            Assert.AreEqual("We need to interactively streamline the process across the board; this is why we've got to 200% address the overarching issues going forward.", output[1]);
            
        }
    }
}
