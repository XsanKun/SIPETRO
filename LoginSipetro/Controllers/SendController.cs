using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using LoginSipetro.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Reflection;

namespace Login.Controllers
{
   
    public class SendController : Controller
    {
       
        public IActionResult Index()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            return View();
        }



        [HttpPost]
        public IActionResult SendEmail(EmailData emailData)
        {

            var startDate = DateTime.Now;
            var endDate = DateTime.Now;
            var timeDifference = endDate.Subtract(startDate);
            var timeDifferenceString = timeDifference.ToString("h' jam 'm' menit 's' detik'");
            var text = $"From: {emailData.From}\r\nTo: {emailData.To}; {emailData.Cc}\r\nSubject: {emailData.Subject}\r\nImportance: High\r\nBody E-mail: \r\n\r\nStatus pengiriman SID SIPETRO {startDate.ToString("dd/MM/yyyy HH:mm:ss")}\r\nStart: {startDate.ToString("dd/MM/yyyy HH:mm:ss")} \r\nEnd: {endDate.ToString("dd/MM/yyyy HH:mm:ss")} \r\nWaktu Proses : {timeDifferenceString} \r\n\r\n\r\n\r\nSalam,\r\nPT KSEI\r\n";
            var email = new MimeMessage();
            var body = new BodyBuilder();

          

                email.From.Add(MailboxAddress.Parse(emailData.From));
                email.To.Add(MailboxAddress.Parse(emailData.To));
                email.Cc.Add(MailboxAddress.Parse(emailData.Cc));
                email.Subject = emailData.Subject;
                if (emailData.File != null)
                {
                    byte[] fileBytes;
                    foreach (var file in emailData.File)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            body.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }
                    }
                }

                body.TextBody = text;
                email.Body = body.ToMessageBody();

                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(emailData.From, emailData.Password);
                smtp.Send(email);
                smtp.Disconnect(true);
                ViewBag.msg = "Message delivered";

             
            
            return RedirectToAction("Index");
        }
    }
}
