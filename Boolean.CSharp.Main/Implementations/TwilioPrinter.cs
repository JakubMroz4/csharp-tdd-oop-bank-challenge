using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main.Implementations
{
    public class TwilioPrinter : IPrinter
    {
        string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

        public TwilioPrinter() 
        {
            TwilioClient.Init(accountSid, authToken);
        }

        public async void Print(string msg)
        {
            var message = await MessageResource.CreateAsync(
            body: msg,
            from: new Twilio.Types.PhoneNumber("+15017122661"),
            to: new Twilio.Types.PhoneNumber("+15558675310"));
        }
    }
}
