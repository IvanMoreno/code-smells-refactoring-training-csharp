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
        var lines = ReadAllLines();

        var employees = new List<Employee>();
        foreach (var line in lines)
        {
            employees.Add(ToEmployee(line));
        }

        return employees;
    }

    static Employee ToEmployee(string line)
    {
        var employeeData = line.Split(", ");
        return new Employee(employeeData[1], employeeData[0], employeeData[2], employeeData[3]);
    }

    List<string> ReadAllLines()
    {
        using var reader = new StreamReader(fileName);
        reader.ReadLine(); // skip header - Smell
        var lines = new List<string>();
        while (reader.ReadLine() is { } str)
        {
            lines.Add(str);
        }

        return lines;
    }
}