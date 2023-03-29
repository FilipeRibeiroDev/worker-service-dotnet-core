using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService.Application.Interfaces;
using WorkerService.Helper;

namespace WorkerService.Application.Services
{
    public class Email : IEmail
    {
        public void SendEmail(string to, string subject, string body)
        {
            var outlook = new EmailHelper("smtp.office365.com", "TESTE@hotmail.com", ENV.PASSWORD);
            outlook.SendEmail(new List<string> { to }, subject, body, new());
        }
    }
}
