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

    public IEnumerable<Employee> GetAllEmployees()
    {
        return ReadAllLines().Select(ToEmployee);
    }

    IEnumerable<string> ReadAllLines()
    {
        using var reader = new StreamReader(fileName);
        reader.ReadLine(); // skip header - Smell
        
        while (reader.ReadLine() is { } str)
        {
            yield return str;
        }
    }

    static Employee ToEmployee(string line)
    {
        var employeeData = line.Split(", ");
        return new Employee(employeeData[1], employeeData[0], employeeData[2], employeeData[3]);
    }
}