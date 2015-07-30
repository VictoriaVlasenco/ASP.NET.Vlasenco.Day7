using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Library
{
    public class Fibonacci
    {
        public static IEnumerable<long> GetNumbers(int count)
        {
            long n = -1, m = 1;
            if (count < 1) yield break;

            for (int i = 0; i < count ; i++)
            {
                long tmp = n + m;
                n = m;
                m = tmp;
                yield return m;
            }
        }
    }
}
