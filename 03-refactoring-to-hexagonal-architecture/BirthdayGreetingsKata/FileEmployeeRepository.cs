using System.Collections.Generic;
using System.IO;

namespace BirthdayGreetingsKata;

public class FileEmployeeRepository
{
    readonly string fileName;

    public FileEmployeeRepository(string fileName)
    {
        this.fileName = fileName;
    }

    public List<Employee> GetAllEmployees()
    {
        using var reader = new StreamReader(fileName);
        reader.ReadLine(); // skip header - Smell
        var employees = new List<Employee>();
        while (reader.ReadLine() is { } str)
        {
            var employeeData = str.Split(", ");
            var employee = new Employee(employeeData[1], employeeData[0], employeeData[2], employeeData[3]);
            employees.Add(employee);
        }

        return employees;
    }
}