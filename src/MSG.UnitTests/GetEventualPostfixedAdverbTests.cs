using System.Collections.Generic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class GetEventualPostfixedAdverbTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> { 10, 55, 1, 14, 9, 22, 2, 5, 1, 25, 28, 5, 15, 10, 23, 6, 1 };
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }
    }
}
