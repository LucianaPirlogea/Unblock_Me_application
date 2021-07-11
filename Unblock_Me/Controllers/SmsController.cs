using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;

namespace Unblock_Me.Controllers
{
    public class SmsController : Controller
    {
        public IActionResult SendSms()
        {
            var accountSid = "AC9b481b628e6aa0f9668ed170e2c0c326";
            var authToken = "1e88a04d1204437a37f94c343d0bd500";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+40754011618");
            var from = new PhoneNumber("+14843809089");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Frate, ma blocasi in parcare."
                );
            return View();
        }
    }
}
