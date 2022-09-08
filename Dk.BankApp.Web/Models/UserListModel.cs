namespace Dk.BankApp.Web.Models
{
    public class UserListModel // Data.Entities'deki propertylerin içinden kullanıcıya göstermek istediklerimi belirliyorum ve buraya alıyorum.
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    
}
