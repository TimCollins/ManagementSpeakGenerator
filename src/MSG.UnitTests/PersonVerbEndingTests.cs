using System.Collections.Generic;
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
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> { 17, 5, 9, 10, 1, 1, 1, 1 };    
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
    }
}
