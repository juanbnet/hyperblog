using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {

            //EXTENSION METHOD 
            //IEnumerable<Employee> developers = new Employee[]
            //{
            //    new Employee {Id=1,Name="John" },
            //    new Employee {Id=2,Name="Baptist" }
            //};

            //IEnumerable<Employee> sales = new List<Employee>()
            //{
            //    new Employee {Id=3,Name="Alex" }
            //};

            //Console.WriteLine(developers.Counter());

            //IEnumerator<Employee> enumerator = developers.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current.Name);
            //}


            //USING LAMBDA EXPRESSION

            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) =>
            {
                int temp = x + y;
                return temp;
            };

            Console.WriteLine(square(add(3, 5)));

            IEnumerable<Employee> developers = new Employee[]
            {
                    new Employee {Id=1,Name="John" },
                    new Employee {Id=2,Name="Baptist" }
            };

            IEnumerable<Employee> sales = new List<Employee>
            {
                new Employee {Id=3,Name="Alex" }
            };

            //1.Technique - Named Method
            //foreach (var employee in developers.Where(NameStartsWithJ))
            //{
            //    Console.WriteLine(employee.Name);
            //}


            //2. Technique - Delegate
            //foreach (var employee in developers.Where(
            //    delegate (Employee employee)
            //    {
            //        return employee.Name.StartsWith("J");
            //    }))
            //{
            //    Console.WriteLine(employee.Name);
            //}


            var query = developers.Where(e => e.Name.Length == 7)
                                  .OrderByDescending(e => e.Name);


            var query2 = from developer in developers
                        where developer.Name.Length == 7
                        orderby developer.Name descending
                        select developer;



            //3. Technique - Lambda Expression
            foreach (var employee in query2)
            {
                Console.WriteLine(employee.Name);
            }


        }

        private static bool NameStartsWithJ(Employee employee)
        {
            return employee.Name.StartsWith("B");
        }
    }
}
