using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LW_DM_Kombinatorika_WPF
{
    public static class CombinatoricsFormulas
    {
        public static string Formula_PermutationNoRepetition = "n!";

        public static BigInteger PermutationNoRepetition(BigInteger n, out string solution)
        {
            // string solution
            solution = $"{n}! = 1";
            for (BigInteger i = 2; i <= n; i++)
            {
                solution += (" * " + i.ToString());
            }
            solution += $" = {Factorial(n)}";
            // computing
            return Factorial(n);            
        }

        public static string Formula_PermutationRepetition = "n! / (n1! * n2! * ... * nm!)";

        public static BigInteger PermutationRepetition(BigInteger[] ni, out string solution)
        {
            BigInteger n = Sum(ni);

            // write init formula
            string t = "";
            for (int i = 0; i < ni.Length; i++)
            {
                t += $" * {ni[i]}!";
            }
            t = t.Remove(0, 3);
            solution = $"{n}! / ({t})";

            // compute denominator factorials
            BigInteger[] denominatorFactorials = new BigInteger[ni.Length];

            t = "";
            for (int i = 0; i < ni.Length; i++)
            {
                // computing
                denominatorFactorials[i] = Factorial(ni[i]);
                // write to string solution
                t += $" * {denominatorFactorials[i]}";
            }
            t = t.Remove(0, 3);
            solution += $" = {Factorial(n)} / ({t})";

            // compute denominator product
            BigInteger t2 = denominatorFactorials.Aggregate((x, y) => x * y);
            solution += $" = {Factorial(n)} / {t2}";

            // compute result
            solution += $" = {Factorial(n) / t2}";

            return Factorial(n) / t2;
        }

        public static string Formula_AccommodationNoRepetition = "n! / (n - m)!";

        public static BigInteger AccommodationNoRepetition(BigInteger n, BigInteger m, out string solution)
        {
            solution = $"{n}! / ({n} - {m})! = {n}! / {n - m}! = {Factorial(n)} / {Factorial(n - m)} = {Factorial(n) / Factorial(n - m)}";
            return Factorial(n) / Factorial(n - m);
        }

        public static string Formula_AccommodationRepetition = "n^m";

        public static BigInteger AccommodationRepetition(BigInteger n, BigInteger m, out string solution)
        {
            solution = $"{n}^{m} = {Pow(n, m)}";
            return Pow(n, m);
        }

        public static string Formula_CombinationNoRepetition = "n! / (m! * (n - m)!) = A / m!";

        public static BigInteger CombinationNoRepetition(BigInteger n, BigInteger m, out string solution)
        {
            solution = $"{n}! / ({m}! * ({n} - {m})!) = {n}! / ({m}! * {n - m}!) = {Factorial(n)} / ({Factorial(m)} * {Factorial(n - m)}) = {Factorial(n)} / {Factorial(m) * Factorial(n - m)} = {Factorial(n) / (Factorial(m) * Factorial(n - m))}";
            return Factorial(n) / (Factorial(m) * Factorial(n - m));
        }

        public static string Formula_CombinationRepetition = "(n + m - 1)! / (m! * (n - 1)!) = C(n + m - 1, m)";

        public static BigInteger CombinationRepetition(BigInteger n, BigInteger m, out string solution)
        {
            BigInteger res = CombinationNoRepetition(n + m - 1, m, out solution);
            solution = $"C({n} + {m} - 1, {m}) = C({n + m - 1}, {m}) = {solution}";
            return res;
        }

        private static BigInteger Factorial(BigInteger n)
        {
            BigInteger res = 1;

            for (BigInteger i = 2; i <= n; i++)
            {
                res *= i;
            }

            return res;
        }

        private static BigInteger Sum(BigInteger[] values)
        {
            BigInteger sum = 0;

            for (long i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }

            return sum;
        }

        private static BigInteger Pow(BigInteger x, BigInteger y)
        {
            BigInteger res = 1;

            for (BigInteger i = 0; i < y; i++)
            {
                res *= x;
            }

            return res;
        }
    }
}
