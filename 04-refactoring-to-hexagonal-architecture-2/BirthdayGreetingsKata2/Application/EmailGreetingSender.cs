using System.Collections.Generic;
using System.Net.Mail;
using BirthdayGreetingsKata2.Core;

namespace BirthdayGreetingsKata2.Application;

public class EmailGreetingSender
{
    string _smtpHost;
    int _smtpPort;
    string _sender;

    public void Send(List<GreetingMessage> messages, string smtpHost, int smtpPort, string sender)
    {
        foreach (var message in messages)
        {
            var recipient = message.To();
            var body = message.Text();
            var subject = message.Subject();
            SendMessage(smtpHost, smtpPort, sender, subject, body, recipient);
        }
    }

    void SendMessage(string smtpHost, int smtpPort, string sender,
        string subject, string body, string recipient)
    {
        // Create a mail session
        var smtpClient = new SmtpClient(smtpHost)
        {
            Port = smtpPort
        };

        // Construct the message
        var msg = new MailMessage
        {
            From = new MailAddress(sender),
            Subject = subject,
            Body = body
        };
        msg.To.Add(recipient);

        // Send the message
        SendMessage(msg, smtpClient);
    }

    // made protected for testing :-(
    public virtual void SendMessage(MailMessage msg, SmtpClient smtpClient)
    {
        smtpClient.Send(msg);
    }
}