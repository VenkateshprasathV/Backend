using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Student //property, Model, entity
    {
        [Key]
        public int Id { get; set; } // primary key
        [Required]
        public string?Name { get; set; } // null;
        public int Age { get; set; }
    }
}
