using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        return lines.Select(ToEmployee).ToList();
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