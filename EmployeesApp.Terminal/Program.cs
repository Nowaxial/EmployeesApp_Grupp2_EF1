using EmployeesApp.Application.Employees.Services;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Infrastructure.Persistance;
using EmployeesApp.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Terminal;
internal static class Program
{

    //DbContext<ApplicationContext> context = new DbContextOptions<ApplicationContext>();
    static DbContextOptions<ApplicationContext> options = new DbContextOptionsBuilder<ApplicationContext>()
        .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EmployeesAppDB;Trusted_Connection=True;")
        .Options;
    static readonly EmployeeService employeeService = new(new EmployeeRepository(new ApplicationContext(options)));

    static void Main(string[] args)
    {
        ListAllEmployees();
        ListEmployee(562);
    }

    private static void ListAllEmployees()
    {
        foreach (var item in employeeService.GetAll())
            Console.WriteLine(item.Name);

        Console.WriteLine("------------------------------");
    }

    private static void ListEmployee(int employeeID)
    {
        Employee? employee;

        try
        {
            employee = employeeService.GetById(employeeID);
            Console.WriteLine($"{employee?.Name}: {employee?.Email}: {employee?.Salary} ");
            Console.WriteLine("------------------------------");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"EXCEPTION: {e.Message}");
        }
    }
}
