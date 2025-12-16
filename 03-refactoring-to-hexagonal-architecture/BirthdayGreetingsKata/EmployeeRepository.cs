using System.Collections.Generic;

namespace BirthdayGreetingsKata;

public interface EmployeeRepository
{
    IEnumerable<Employee> GetAllEmployees();
}