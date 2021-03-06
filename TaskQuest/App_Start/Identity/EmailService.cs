﻿using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace TaskQuest.Identity
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            if (Util.HasInternetConnection())
                return SendMail(message);
            return Task.FromResult(0);
        }

        // Implementação de e-mail manual
        private Task SendMail(IdentityMessage message)
        {
            var msg = new MailMessage();
            msg.From = new MailAddress(ConfigurationManager.AppSettings["mailAccount"], "TaskQuest");
            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Body, null, "text/html"));
            msg.IsBodyHtml = true;
            var smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["mailAccount"], ConfigurationManager.AppSettings["mailPassword"]);
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;

            bool isSent = false;

            while (!isSent)
            {
                try
                {
                    smtpClient.Send(msg);
                    isSent = true;
                }
                catch (Exception) {}
            }

            return Task.FromResult(0);

        }
    }
}