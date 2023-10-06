using System.ComponentModel.DataAnnotations;

namespace TechniNetGameAPI.Models
{
    public class GameCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int IdGenre { get; set; }
    }
}
