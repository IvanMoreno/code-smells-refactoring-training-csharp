using System.Net.Mail;

namespace BirthdayGreetingsKata2.Application;

public class EmailGreetingSender
{
    public void SendMessage(MailMessage msg, SmtpClient smtpClient)
    {
        smtpClient.Send(msg);
    }
}