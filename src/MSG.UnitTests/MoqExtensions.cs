using System;
using System.Collections;
using System.Collections.Generic;
using Moq.Language.Flow;

namespace MSG.UnitTests
{
    public static class MoqExtensions
    {
        /// <summary>
        /// Generic method which allows a queue of return values to be returned from a mock object.
        /// </summary>
        /// <typeparam name="T">The type of the array which is returned element by element.</typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="setup">Instance of object which implements ISetup</param>
        /// <param name="results">The array of values.</param>
        public static void ReturnsInOrder<T, TResult>(this ISetup<T, TResult> setup,
          params TResult[] results) where T : class
        {
            setup.Returns(new Queue<TResult>(results).Dequeue);
        }

        /// <summary>
        /// An overload of ReturnsInOrder which allows an exception to be thrown.
        /// </summary>
        /// <typeparam name="T">The type of the array which is returned element by element.</typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="setup">Instance of object which implements ISetup</param>
        /// <param name="results">The array of values.</param>
        public static void ReturnsInOrder<T, TResult>(this ISetup<T, TResult> setup,
            params object[] results) where T : class
        {
            var queue = new Queue(results);
            setup.Returns(() =>
            {
                var result = queue.Dequeue();
                if (result is Exception)
                {
                    throw result as Exception;
                }
                return (TResult)result;
            });
        }
    }
}
