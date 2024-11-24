namespace AenEnterprise.ServiceImplementations.ViewModel
{
    public class AccountView
    {
        public int AccountId { get; set; }             // Primary Key
        public string AccountName { get; set; }        // Name of the account (e.g., Cash in Hand, Inventory)
        public string AccountNumber { get; set; }      // Unique account number or code
        public decimal Balance { get; set; }           // Account balance

        // Foreign Key
        public int AccountTypeId { get; set; }
    }
}