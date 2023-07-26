// See https://aka.ms/new-console-template for more information

using HRAdminstrationAPI;
using System.Collections.Generic;
using System.Linq;
//namespace SchoolHRAdminstration { }

/*
 LINQ (Language Integrated Query) is a feature of C# that allows you to 
write queries that operate on collections of objects, databases, and 
other data sources. LINQ provides a unified syntax and programming model
for querying data, regardless of where the data is stored.
 */

/*an extension method is a static method that provides additional functionality to an existing class or interface.
Extension methods allow you to "extend" the functionality of a class or interface without modifying its source code.
They are a way of adding new methods to a type without creating a new derived type or modifying the original type.
To define an extension method in C#, you need to create a static class and define a static method within that class.
The first parameter of the method must be of the type you want to extend, and it must be preceded by the this keyword.*/

//Delegates like pointer but with additional features like support for multicast invocation and type safety

public enum EmployeeType
{
    Teacher,
    HeadofDepartment,
    DeputyHeadMaster,
    HeadMaster
}

class Program
{
    static void Main(string[] args)
    {
        decimal totalSalaries = 0;
        List<IEmployee> employees = new List<IEmployee>();

        SeedData(employees);

        //foreach (IEmployee employee in employees)
        //{
        //    totalSalaries += employee.Salary;
        //}

        //Console.WriteLine($"Total Annual Salaries (including bonus): {totalSalaries}");

        Console.WriteLine($"Total Annual Salaries (including bonus): {employees.Sum(e => e.Salary)}");
        Console.ReadKey();
    }

    public static void SeedData(List<IEmployee> employees)
    {
        //Instantiating an interface
        IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Bob", "Fisher", 40000);
        employees.Add(teacher1);

        IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Mihret", "Agegnehu", 500000);
        employees.Add(teacher2);

        IEmployee headofDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadofDepartment, 3, "Leni", "Poe", 100000);
        employees.Add(headofDepartment);

        IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "Deamon", "Salvator", 5200000);
        employees.Add(deputyHeadMaster);

        IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 5, "Stefan", "Salvator", 1500000);
        employees.Add(headMaster);


    }
}

public class Teacher : EmployeeBase
{
    //since there no set; it means it's readonly
    //base.Salary refers to the salary on the base class
    // m suffix is used to to specify decimal other wise it would be double and would need to be cast
    public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); }
}
public class HeadofDepartment : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }
}

public class DeputyHeadMaster : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }
}

public class HeadMaster : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }
}

public static class EmployeeFactory
{
    public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
    {
        IEmployee employee = null;
        switch (employeeType)
        {
            case EmployeeType.Teacher:
                //employee = new Teacher { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                break;

            case EmployeeType.HeadofDepartment:
                employee = FactoryPattern<IEmployee, HeadofDepartment>.GetInstance();
                break;

            case EmployeeType.DeputyHeadMaster:
                employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                break;

            case EmployeeType.HeadMaster:
               employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                break;

            default:
                break;
        }

        if (employee != null)
        {
            employee.Id = id;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Salary = salary;
        }
        else
        {
            throw new NullReferenceException();
        }
        return employee;
    }

    
}


