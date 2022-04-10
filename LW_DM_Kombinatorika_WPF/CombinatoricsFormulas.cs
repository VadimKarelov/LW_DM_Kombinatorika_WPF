using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_DM_Kombinatorika_WPF
{
    public static class CombinatoricsFormulas
    {
        public static string Formula_PermutationNoRepetition = "n!";

        public static long PermutationNoRepetition(long n, out string solution)
        {
            // string solution
            solution = $"{n}! = 1";
            for (long i = 2; i <= n; i++)
            {
                solution += (" * " + i.ToString());
            }
            solution += $" = {Factorial(n)}";
            // computing
            return Factorial(n);
        }

        public static string Formula_PermutationRepetition = "n! / (n1! * n2! * ... * nm!)";

        public static long PermutationRepetition(long[] ni, out string solution)
        {
            long n = ni.Sum();

            // write init formula
            string t = "";
            for (int i = 0; i < ni.Length; i++)
            {
                t += $" * {ni[i]}!";
            }
            t = t.Remove(0, 3);
            solution = $"{n}! / ({t})";

            // compute denominator factorials
            long[] denominatorFactorials = new long[ni.Length];

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
            long t2 = denominatorFactorials.Aggregate((x, y) => x * y);
            solution += $" = {Factorial(n)} / {t2}";

            // compute result
            solution += $" = {Factorial(n) / t2}";

            return Factorial(n) / t2;
        }

        public static string Formula_AccommodationNoRepetition = "n! / (n - m)!";

        public static long AccommodationNoRepetition(long n, long m, out string solution)
        {
            solution = $"{n}! / ({n} - {m})! = {n}! / {n - m}! = {Factorial(n)} / {Factorial(n - m)} = {Factorial(n) / Factorial(n - m)}";
            return Factorial(n) / Factorial(n - m);
        }

        public static string Formula_AccommodationRepetition = "n^m";

        public static long AccommodationRepetition(long n, long m, out string solution)
        {
            solution = $"{n}^{m} = {Math.Pow(n, m)}";
            return (long)Math.Pow(n, m);
        }

        public static string Formula_CombinationNoRepetition = "n! / (m! * (n - m)!) = A / m!";

        public static long CombinationNoRepetition(long n, long m, out string solution)
        {
            solution = $"{n}! / ({m}! * ({n} - {m})!) = {n}! / ({m}! * {n - m}!) = {Factorial(n)} / ({Factorial(m)} * {Factorial(n - m)}) = {Factorial(n)} / {Factorial(m) * Factorial(n - m)} = {Factorial(n) / (Factorial(m) * Factorial(n - m))}";
            return Factorial(n) / (Factorial(m) * Factorial(n - m));
        }

        public static string Formula_CombinationRepetition = "(n + m - 1)! / (m! * (n - 1)!) = C(n + m - 1, m)";

        public static long CombinationRepetition(long n, long m, out string solution)
        {
            long res = CombinationNoRepetition(n + m - 1, m, out solution);
            solution = $"C({n} + {m} - 1, {m}) = C({n + m - 1}, {m}) = {solution}";
            return res;
        }

        private static long Factorial(long n)
        {
            long res = 1;

            for (long i = 2; i <= n; i++)
            {
                res *= i;
            }

            return res;
        }
    }
}
