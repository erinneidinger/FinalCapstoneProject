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

namespace FinalCapstone.Controllers
{
    public class SMSController : TwilioController
    {
        // GET: SMS
        public ActionResult SendSms()
        {
            var accountSid = KeyPrivate.TwilioAccountSid;
            var authToken = KeyPrivate.TwilioAuthToken;
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(KeyPrivate.MyPhoneNumber);
            var from = new PhoneNumber(KeyPrivate.TwilioNumber);

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "CODE KANSAS!");
            return Content(message.Sid);
        }

        //public ActionResult ReceiveSms()
        //{
        //    var response = new MessagingResponse();
        //    response.Message("This phone will combust in 10 seconds");

        //    return TwilML(response);
        //}
    }
}