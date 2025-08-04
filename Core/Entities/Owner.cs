namespace Core.Entities
{
   public class Owner :EntityBase
    {
        public string FullName { get; set; }
        public string Profil {  get; set; }//job title
        public string Avatar { get; set; }//peronel image
        public Address? Address { get; set; }
    }

}
