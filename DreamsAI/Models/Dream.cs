using System.ComponentModel.DataAnnotations;

namespace DreamsAI.Models
{
    public class Dream
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; } // За съхранение на часа
    }


}
