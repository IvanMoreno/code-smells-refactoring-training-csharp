using System.Net.Mail;

namespace BirthdayGreetingsKata2.Application;

public class EmailGreetingSender
{
    // made protected for testing :-(
    public virtual void SendMessage(MailMessage msg, SmtpClient smtpClient)
    {
        smtpClient.Send(msg);
    }
}