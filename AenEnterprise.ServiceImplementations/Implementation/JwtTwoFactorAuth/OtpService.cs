using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.Implementation.JwtTwoFactorAuth
{
    public class OtpService
    {
        private readonly Dictionary<string, string> _otpService = new Dictionary<string, string>();

        public async Task StoreOtpValue(string userName, string otp)
        {
            _otpService[userName] = otp;
            await Task.Delay(TimeSpan.FromMinutes(5));
            _otpService.Remove(userName);
        }

        public async Task<bool> ValidateOtp(string userName, string otp)
        {
            if (_otpService.TryGetValue(userName, out string otpValue) && otpValue == otp)
            {
                return true;
            }

            return false;
        }
    }
}
