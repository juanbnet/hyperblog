using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    public static class MyLinq
    {        
         //This is one implementation of filter but this is not the way LINQ actually implement the where operator 
           
        //public static IEnumerable<T> Filter<T>(this IEnumerable<T> source,
        //                                        Func<T,bool> predicate)
        //{
        //    var result = new List<T>();

        //    foreach (var item in source)
        //    {
        //        if(predicate(item))
        //        {
        //            result.Add(item);
        //        }
        //    }

        //    return source;
        //}


        //Another way
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source,
                                                Func<T,bool> predicate)
        {
            var result = new List<T>();

            foreach (var item in source)
            {
                if(predicate(item))
                {
                    result.Add(item);
                }
            }



            return result;
        }
    }
}
