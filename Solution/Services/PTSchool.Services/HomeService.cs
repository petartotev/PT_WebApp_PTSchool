using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Home;
using System;
using System.Net;
using System.Net.Mail;

namespace PTSchool.Services
{
    public class HomeService : IHomeService
    {
        public bool SendEmail(EmailSendServiceModel model)
        {
            #region CommentsOnSmtpClient
            // MailAddress fromAddress/string fromPassword - email/password in Gmail to get access to the SmtpClient Host ("smpt.gmail.com").
            // That would throw a SmtpException: 5.7.0 Authentication Required.
            // You would also receive an email in Gmail saying "Critical security alert".
            // What you need to do is to press "Check Activity" => Less secure app blocked => Learn more => Less secure app access => Allow less secure apps: ON.
            // Now it should work.
            #endregion

            MailAddress fromAddress = new MailAddress("gmail@gmail.gmail");
            string fromPassword = "gmailpassword";
            var toAddress = new MailAddress("domain@domain.domain");

            string subject = model.Subject;
            string body = model.Message;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            try
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                    return true;
                }
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
