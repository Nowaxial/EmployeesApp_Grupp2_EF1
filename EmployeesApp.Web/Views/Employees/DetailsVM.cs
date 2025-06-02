namespace EmployeesApp.Web.Views.Employees
{
    public class DetailsVM
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required decimal Salary { get; set; } = 0.0m; // Default value for Salary
    }
}
