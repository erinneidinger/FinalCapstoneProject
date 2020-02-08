using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using FinalCapstone.Models;
using Microsoft.AspNet.Identity;

namespace FinalCapstone.Controllers
{
    public class SMSController : TwilioController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: SMS
        public ActionResult SendSms()
        {
            var accountSid = SecretKeys.TwilioAccountSid;
            var authToken = SecretKeys.TwilioAuthToken;
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(SecretKeys.MyPhoneNumber);
            var from = new PhoneNumber(SecretKeys.TwilioNumber);

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "CODE KANSAS!");
            return Content(message.Sid);
        }

        public ActionResult SendInviteSms()
        {
            var userId = User.Identity.GetUserId();
            var accountSid = SecretKeys.TwilioAccountSid;
            var authToken = SecretKeys.TwilioAuthToken;
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(SecretKeys.MyPhoneNumber);
            var from = new PhoneNumber(SecretKeys.TwilioNumber);
            var member = db.Teammembers.Where(a => a.ApplicationId == userId).FirstOrDefault();
            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Hello! " + member.FirstName + " has invited you to join their organization on SafetyNet! Please follow the link in order to register for your new account: https://localhost:44373/Account/Register");
            return Content(message.Sid);
        }
    }
}