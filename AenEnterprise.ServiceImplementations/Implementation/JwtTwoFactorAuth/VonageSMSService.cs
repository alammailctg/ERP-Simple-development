using System;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

public class VonageSMSService
{
    private readonly string _apiKey;
    private readonly string _apiSecret;
    private readonly string _fromNumber;
    private readonly VonageClient _client;

    public VonageSMSService(string apiKey, string apiSecret, string fromNumber)
    {
        _apiKey = apiKey;
        _apiSecret = apiSecret;
        _fromNumber = fromNumber;

        // Initialize the Vonage client with API key and secret
        var credentials = Credentials.FromApiKeyAndSecret(_apiKey, _apiSecret);
        _client = new VonageClient(credentials);
    }

    public async Task<string> SendOtpAsync(string toNumber, string otp)
    {
        // Create the message text
        var textMessage = $"Your OTP is: {otp}";

        // Create the SMS request
        var request = new Vonage.Messaging.SendSmsRequest
        {
            To = toNumber,
            From = _fromNumber,
            Text = textMessage
        };

        try
        {
            // Send the SMS
            var response = await _client.SmsClient.SendAnSmsAsync(request);
            if (response.Messages[0].Status == "0")
            {
                return "Message sent successfully!";
            }
            else
            {
                return $"Message failed: {response.Messages[0].ErrorText}";
            }
        }
        catch (Exception ex)
        {
            return $"Exception: {ex.Message}";
        }
    }
}
