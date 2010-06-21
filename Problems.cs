using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerCsharp
{
    class Problems
    {

        # region problem1
        /// <summary>
        /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        /// Find the sum of all the multiples of 3 or 5 below 1000.
        /// </summary>
        /// <returns></returns>
        public static int _1(int limit = 999)
        {
            return Enumerable.Range(1, limit)
                .Where(x => x % 3 == 0 || x % 5 == 0)
                .Sum();
        }
        #endregion

        #region problem2
        /// <summary>
        /// Find the sum of all the even-valued terms in the fibonachi sequence which do not exceed four million.
        /// </summary>
        /// <returns></returns>
        public static long _2()
        {
            return fibonacci().TakeWhile(x => (x <= 4000000)).Where(x => x % 2 == 0).Sum();
        }

        /// <summary>
        /// Lazy sequence generator for fibonacci numbers. Goes well with ".TakeWhile" etc.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>fibonachi sequence starting with first and second (parameters)</returns>
        public static IEnumerable<int> fibonacci(int first = 1, int second = 2)
        {
            yield return first;
            yield return second;
            int n;

            while (true)
            {
                yield return n = first + second;
                first = second;
                second = n;
            }
        }
        #endregion

        #region problem3
        /// <summary>
        /// The prime factors of 13195 are 5, 7, 13 and 29.
        /// What is the largest prime factor of the number 600851475143 ?
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static long _3(long val = 600851475143)
        {
            //query for all odd numbers (lazy)
            var odds =
            from n in Enumerable.Range(0, int.MaxValue)
            select 3 + (long)n * 2;

            //query for all prime numbers (lazy)
            var primes = (new[] { 2L }).Concat(
            from p in odds
            where !odds.TakeWhile(odd => odd * odd <= p).Any(odd => p % odd == 0)
            select p);

            return primes.TakeWhile(p => p * p <= val).Where(p => val % p == 0).Last();
        }
        #endregion

        #region problem4
        /// <summary>
        /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91  99.
        /// Find the largest palindrome made from the product of two 3-digit numbers.
        /// </summary>
        /// <returns></returns>
        public static int _4()
        {
            //all three digit numbers
            var threeDigitNumbers = Enumerable.Range(100,900); //Range takes start and COUNT, not first and last

            //all producsts of two three-digit numbers
            var products = (
                from a in threeDigitNumbers
                from b in threeDigitNumbers
                select a * b).Distinct();

            //select largest palindrome - see IsPalindrome extension method
            return products.Where(x => x.IsPalindrome()).Max();
        }
        #endregion

        #region problem5
        /// <summary>
        /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
        /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
        /// </summary>
        public static int _5()
        {
            int[] divisibleBy = { 2, 3, 4, 5, 6, 7, 9, 11, 13, 14, 15, 16, 17, 19 }; //everything divisible by 2 AND 4 is also divisible by 8.. similarly for 10, 12, 20

            return
                Enumerable.Range(1, Int32.MaxValue).Where(x => divisibleBy.All(d => x % d == 0)).FirstOrDefault();
               
        }
        #endregion

        #region problem 6
        /// <summary>
        /// The sum of the squares of the first ten natural numbers is,
        /// 12 + 22 + ... + 102 = 385
        /// The square of the sum of the first ten natural numbers is,
        /// (1 + 2 + ... + 10)2 = 552 = 3025
        /// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025  385 = 2640.
        /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
        /// </summary>
        /// <returns></returns>
        public static int _6()
        {
            var sum100 = 1.To(100).Sum();

            var sumOfSquares = 1.To(100).Select(x => x * x).Sum();

            return (sum100 * sum100) - sumOfSquares;
        }
        #endregion

    }
}
