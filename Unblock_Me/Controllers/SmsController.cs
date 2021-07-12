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
            var authToken = "de7934a7599937123c67283824012385";
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
