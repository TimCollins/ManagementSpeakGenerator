using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class PersonVerbEndingTests
    {
        // This will be testing the output from GetPersonVerbAndComplement(), 
        // GetPersonVerbHavingBadThingComplement() and GetRandomArticle()

            //if (result > 0 && result < 11)
            //{
            //    return GetPersonVerbAndComplement(plurality);
            //}

            //if (result > 10 && result < 16)
            //{
            //    return GetPersonVerbHavingBadThingComplement(plurality) + GetRandomArticle();
            //}

            //if (result > 15 && result < 96)
            //{
            //    return GetPersonHavingThingComplement(plurality) + GetRandomArticle();
            //}

        [Test]
        public void VerifyPersonVerbAndComplementStreamline()
        {
            MoqUtil.SetupRandMock(17, 5, 9, 10, 1, 1, 1, 1);

            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("streamline the process "));
        }

        [Test]
        public void VerifyPersonVerbAndComplementOverarching()
        {
            MoqUtil.SetupRandMock(17, 5, 9, 10, 1, 1, 2, 1);

            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("address the overarching issues "));
        }
    }
}
