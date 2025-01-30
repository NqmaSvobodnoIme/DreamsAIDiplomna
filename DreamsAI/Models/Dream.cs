using System;
using System.ComponentModel.DataAnnotations;

namespace DreamsAI.Models
{
    public class Dream
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Дата и час на създаване

        // Добавяне на отделно поле за време, ако е нужно
        public TimeSpan Time { get; set; }
        public string Category { get; set; }
        //public string Analysis { get; set; }


    }


}
