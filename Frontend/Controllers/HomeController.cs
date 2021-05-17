using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Frontend.Models;
using Frontend.Repository;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repo;
        private readonly SendMail sendEmail;

        public HomeController(IRepository repo, SendMail sendEmail)
        {
            this.repo = repo;
            this.sendEmail = sendEmail;
        }
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult GetUserInput(Customer model)
        {
            var AccountNumber = repo.GetAccountNumber(model);
            var SendMail = sendEmail.NewEmail(model.Email, "Infinion Bank OTP", "" );

            
            return LocalRedirect("/Home/OTP");
        }

        // public ActionResult OTP( )
        // {
        //     var OTP = SendMail.
        // }



    }
}
