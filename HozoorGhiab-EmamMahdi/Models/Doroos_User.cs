namespace HozoorGhiabEmamMahdi.Models
{
    public class Doroos_User
    {
        public int UserId { get; set; }
        public int DoroosId { get; set; }
        public User User { get; set; }
        public Doroos Doroos { get; set; }
    }
}
