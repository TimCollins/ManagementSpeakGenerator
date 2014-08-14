using Moq;
using MSG.DomainLogic;

namespace MSG.UnitTests
{
    /// <summary>
    /// Utility methods for operations that use the Moq library and are referenced from various places.
    /// </summary>
    public class MoqUtil
    {
        internal static void SetupRandMock(params int[] values)
        {
            Mock<IRandomNumber> mockRand = new Mock<IRandomNumber>();
            mockRand.Setup(m => m.GetRand(It.IsAny<int>(), It.IsAny<int>())).ReturnsInOrder(values);
            DomainFactory.RandomNumber = mockRand.Object;
        }

        internal static void SetupRandMock(int result)
        {
            Mock<IRandomNumber> mockRand = new Mock<IRandomNumber>();
            mockRand.Setup(m => m.GetRand(It.IsAny<int>(), It.IsAny<int>())).Returns(result);

            DomainFactory.RandomNumber = mockRand.Object;
        }

        internal static void UndoMockRandomNumber()
        {
            DomainFactory.RandomNumber = null;
        }
    }
}
