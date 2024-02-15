namespace api.Models
{
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public List<Anime> watchedList { get; set; } = new List<Anime>();
    }
}