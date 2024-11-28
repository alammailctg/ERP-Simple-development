namespace AenEnterprise.FrontEndMvc.Models.LicenseDto
{
    public class LicenseGenerationRequest
    {
        public string ClientName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string SecretKey { get; set; }
    }
}
