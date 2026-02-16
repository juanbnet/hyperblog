using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    public static class MyExtMethod
    {

        public static int Counter<T>(this IEnumerable<T> sequence)
        {
            int count = 0;

            foreach (var i in sequence)
            {
                count += 1;

            }
            return count;
        }

        public static double ToDouble(this string data)
        {
            double result = double.Parse(data);

            return result;



        }

    }
}
