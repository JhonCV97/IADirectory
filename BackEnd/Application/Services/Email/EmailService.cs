using Application.DTOs.Email;
using Application.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        void IEmailService.SendEmail(EmailDto request)
        {
            MailAddress from = new MailAddress("artificialesinteligencias00@gmail.com");
            MailAddress to = new MailAddress(request.To);
            MailMessage message = new MailMessage(from, to);
            message.Subject = request.Subject;
            message.Body = request.Body;
            message.IsBodyHtml = true;
            // Use the application or machine configuration to get the
            // host, port, and credentials._config.GetSection("EmailHost").Value _config.GetSection("EmailUser").Value, _config.GetSection("EmailPassword").Value
            // Ethereal.email
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("artificialesinteligencias00@gmail.com", "roihwzoadmxhvajo");
            client.EnableSsl = true;
            Console.WriteLine("Sending an email message to {0} at {1} by using the SMTP host={2}.",
                to.User, to.Host, client.Host);
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


    }
}
