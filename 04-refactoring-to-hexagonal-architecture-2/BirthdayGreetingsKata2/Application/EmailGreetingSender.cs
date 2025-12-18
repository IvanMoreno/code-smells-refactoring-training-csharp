using System.Collections.Generic;
using System.Net.Mail;
using BirthdayGreetingsKata2.Core;

namespace BirthdayGreetingsKata2.Application;

public class EmailGreetingSender : GreetingSender
{
    readonly string _smtpHost;
    readonly int _smtpPort;
    readonly string _sender;

    public EmailGreetingSender(string smtpHost, int smtpPort, string sender)
    {
        _smtpHost = smtpHost;
        _smtpPort = smtpPort;
        _sender = sender;
    }

    public void Send(List<GreetingMessage> messages)
    {
        foreach (var message in messages)
        {
            SendMessage(message);
        }
    }

    void SendMessage(GreetingMessage message)
    {
        // Create a mail session
        var smtpClient = new SmtpClient(_smtpHost)
        {
            Port = _smtpPort
        };

        // Construct the message
        var msg = new MailMessage
        {
            From = new MailAddress(_sender),
            Subject = message.Subject(),
            Body = message.Text()
        };
        msg.To.Add(message.To());

        // Send the message
        SendMessage(msg, smtpClient);
    }

    // made protected for testing :-(
    public virtual void SendMessage(MailMessage msg, SmtpClient smtpClient)
    {
        smtpClient.Send(msg);
    }
}