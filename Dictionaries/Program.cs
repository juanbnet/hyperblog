// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var employees = new List<Employee>
{
    new Employee {Name="Jake Smith", Department= "Space Navigation", Salary=25000},
    new Employee {Name="Anne Smith", Department= "Space Navigation", Salary=29000},
    new Employee {Name="Barbara Oak", Department= "Xenobiology", Salary=21500},
    new Employee {Name="Damien Parker", Department= "Xenobiology", Salary=22000},
    new Employee {Name="Nisha Patel", Department= "Mechanics", Salary=21000},
    new Employee {Name="Gustavo Sanchez", Department= "Mechanics", Salary=21000},
};

var result = CalculateAveragePerDepartment(employees);
Dictionary<string, decimal> CalculateAveragePerDepartment(IEnumerable<Employee> employees)
{
    var employeesPerDepartments = new Dictionary<string, List<Employee>>();


    foreach(Employee employee in employees)
    {
        if(!employeesPerDepartments.ContainsKey(employee.Department))
        {
            employeesPerDepartments[employee.Department]= new List<Employee>();
        }

        employeesPerDepartments[employee.Department].Add(employee);
    }

    return null;

}


class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
}






