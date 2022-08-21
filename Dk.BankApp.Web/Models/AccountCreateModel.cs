namespace Dk.BankApp.Web.Models
{
    public class AccountCreateModel // Data.Entities'deki propertylerin içinden kullanıcıya göstermek istediklerimi belirliyorum ve buraya alıyorum.
    {
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public int ApplicationUserId { get; set; }
    }
}
