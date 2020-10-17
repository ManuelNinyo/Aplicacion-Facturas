using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Services
{
    public class SmtpService
    {
        //readonly SmtpClient smtpClient;
        //readonly string from;
        readonly ISmtpSettings smtpSettings;
        public SmtpService(ISmtpSettings smtpSettings)
        {
            this.smtpSettings = smtpSettings;

        }
        public void sendMessage(Factura factura)
        {
            SmtpClient smtpClient = new SmtpClient(smtpSettings.Host, smtpSettings.Port)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(smtpSettings.Email, smtpSettings.Pasword),
                EnableSsl = true
            };
            MailMessage message = new MailMessage(smtpSettings.Email, factura.Cliente.Email)
            {
                Subject = "recordatorio de factura de prueba",
                Body= $"<strong>{factura.Estado}</strong>",
                IsBodyHtml = true,

            };
            smtpClient.Send(message);
            smtpClient.Dispose();

        }
    }
}
