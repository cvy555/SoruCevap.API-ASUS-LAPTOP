namespace SoruCevap.API.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
        public string VideoUrl { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }

        public Questions Question { get; set; }
    }

}
