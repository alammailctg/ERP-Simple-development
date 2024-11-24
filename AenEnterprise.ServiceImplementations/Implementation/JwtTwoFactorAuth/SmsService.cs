using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace AenEnterprise.ServiceImplementations.Implementation.JwtTwoFactorAuth
{
    public class SmsService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _twilioPhoneNumber;

        public SmsService(string accountSid, string authToken, string twilioPhoneNumber)
        {
            _accountSid = accountSid;
            _authToken = authToken;
            _twilioPhoneNumber = twilioPhoneNumber;

            // Initialize Twilio client
            TwilioClient.Init(_accountSid, _authToken);
        }

        public async Task SendOtpAsync(string mobileNumber, string otp)
        {
            var message = $"Your OTP is: {otp}";

            try
            {
                var messageResource = await MessageResource.CreateAsync(
                    to: new PhoneNumber(mobileNumber),
                    from: new PhoneNumber(_twilioPhoneNumber),
                    body: message
                );

                Console.WriteLine($"OTP sent to {mobileNumber}: {messageResource.Sid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send OTP: {ex.Message}");
            }
        }
    }
}
 
