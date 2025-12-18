using System.Collections.Generic;
using System.Net.Mail;
using BirthdayGreetingsKata2.Core;

namespace BirthdayGreetingsKata2.Application;

public class BirthdayService
{
    private readonly IEmployeesRepository _employeesRepository;
    readonly EmailGreetingSender _emailGreetingSender;

    public BirthdayService(IEmployeesRepository employeesRepository, EmailGreetingSender emailGreetingSender)
    {
        _employeesRepository = employeesRepository;
        _emailGreetingSender = emailGreetingSender;
    }

    public void SendGreetings(OurDate date, string smtpHost, int smtpPort, string sender)
    {
        _emailGreetingSender.Send(GreetingMessagesFor(EmployeesHavingBirthday(date)));
    }

    private static List<GreetingMessage> GreetingMessagesFor(IEnumerable<Employee> employees)
    {
        return GreetingMessage.GenerateForSome(employees);
    }

    private IEnumerable<Employee> EmployeesHavingBirthday(OurDate today)
    {
        return _employeesRepository.GetAll()
            .FindAll(employee => employee.IsBirthday(today));
    }
}