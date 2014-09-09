namespace MSG.DomainLogic.Interfaces
{
    public interface IRandomNumber
    {
        /// <summary>
        /// Return a random number within the specified range. Note that end is exclusive so for a
        /// range of 1 to 5, start = 1 and end = 6. The value of end must also be greater than or 
        /// equal to start.
        /// </summary>
        /// <param name="start">The inclusive lower bound of the random number.</param>
        /// <param name="end">The exclusive upper bound of the random number.</param>
        /// <returns>A random integer within the specified range.</returns>
        int GetRand(int start, int end);

        /// <summary>
        /// Return a random number within the range of (0..end - 1). 
        /// </summary>
        /// <param name="end">The exclusive upper bound of the random number.</param>
        /// <returns>A random integer within the specified range.</returns>
        int GetRand(int end);
    }
}
