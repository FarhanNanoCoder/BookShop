﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace BulkyBook.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //enables actual mail sender
            //var emailToSend = new MimeMessage();

            //emailToSend.From.Add(MailboxAddress.Parse("farhan.shariar.094@gmail.com"));
            //emailToSend.To.Add(MailboxAddress.Parse(email));
            //emailToSend.Subject = subject;
            //emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

            ////send email
            //using (var emailClient = new SmtpClient)
            //{
            //    emailClient
            //        .Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            //    emailClient.Authenticate("farhan.shariar.094@gmail.com", "pass");
            //    emailClient.Send(emailToSend);
            //    emailClient.Disconnect(true);
            //}
            return Task.CompletedTask;  
        }
    }
}