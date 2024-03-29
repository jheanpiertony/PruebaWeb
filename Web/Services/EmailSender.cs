﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Web.Services
{
    public class EmailSender : IEmailSender
    {
        // Our private configuration variables https://medium.com/@MisterKevin_js/enabling-email-verification-in-asp-net-core-identity-ui-2-1-b87f028a97e0
        private readonly string host;
        private readonly int port;
        private readonly bool enableSSL;
        private readonly string userName;
        private readonly string password;

        // Get our parameterized configuration
        public EmailSender(string host, int port, bool enableSSL, string userName, string password)
        {
            this.host = host;
            this.port = port;
            this.enableSSL = enableSSL;
            this.userName = userName;
            this.password = password;
        }

        // Use our configuration to send the email by using SmtpClient
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSSL
            };
            return client.SendMailAsync(
                new MailMessage(userName, email, subject, htmlMessage) { IsBodyHtml = true }
            );
        }
    }
}
