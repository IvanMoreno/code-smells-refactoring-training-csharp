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
        var lines = new List<string>();
        while (reader.ReadLine() is { } str)
        {
            lines.Add(str);
        }

        var employees = new List<Employee>();
        foreach (var line in lines)
        {
            var employeeData = line.Split(", ");
            var employee = new Employee(employeeData[1], employeeData[0], employeeData[2], employeeData[3]);
            employees.Add(employee);
        }

        return employees;
    }
}