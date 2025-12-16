using System.Collections.Generic;
using System.IO;

namespace BirthdayGreetingsKata;

public class FileEmployeeRepository
{
    string fileName;

    public FileEmployeeRepository()
    {
        
    }

    public FileEmployeeRepository(string fileName)
    {
        this.fileName = fileName;
    }

    public List<Employee> GetAllEmployees(string fileName)
    {
        using var reader = new StreamReader(fileName);
        var str = "";
        str = reader.ReadLine(); // skip header - Smell
        var employees = new List<Employee>();
        while ((str = reader.ReadLine()) != null)
        {
            var employeeData = str.Split(", ");
            var employee = new Employee(employeeData[1], employeeData[0], employeeData[2], employeeData[3]);
            employees.Add(employee);
        }

        return employees;
    }
}