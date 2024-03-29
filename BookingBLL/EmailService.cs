﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using BookingShared.Interfaces;
using Microsoft.Extensions.Options;
using BookingShared.Models;

namespace BookingBLL
{
    public class EmailService : IEmailService
    {
        private ILogger _logger;
        private NetworkCredential _credentials;

        public EmailService(ILogger<EmailService> logger, IOptions<EmailCredentials> emailCredOptions)
        {
            _logger = logger;
            _credentials = new NetworkCredential(emailCredOptions.Value.Email, emailCredOptions.Value.Password);
        }

        public void SendConfirmationEmail(AppUser user)
        {
            var link = $"https://localhost:5001/Account/Confirm/{user.ConfirmationCode}";
            var message = $"Dear {user.FirstName} {user.LastName},\n Thank you for registering on our web site.\n";
            message += $"In order to be able to book the rooms, please confirm you email by pressing the following link:\n";
            message += $"<a href=\"{link}\">{link}</a>\n";
            message += $"Kind regards, Airat";

            SendEmail($"{user.FirstName} {user.LastName}", user.Email, message);
        }

        public void SendEmail(string name, string email, string message)
        {
            try
            {
                var mail = new MailMessage()
                {
                    From = new MailAddress("musinayrat@gmail.com"),
                    Subject = "Confirmation Email",
                    Body = message,
                    IsBodyHtml = true
                };
                mail.To.Add(new MailAddress(email));

                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = _credentials
                };

                client.Send(mail);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
            }
        }
    }
}
