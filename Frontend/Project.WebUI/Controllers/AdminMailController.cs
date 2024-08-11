using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Project.WebUI.Models.Mail;

namespace Project.WebUI.Controllers
{
    [Authorize]

    public class AdminMailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage(); 
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelletAdmin", "[gmail adress]");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Content;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, false);
            await client.AuthenticateAsync("[gmail adress]", "[Password key from google]"); 
            await client.SendAsync(mimeMessage);
            await client.DisconnectAsync(true);


            return View();
        }
    }
}
