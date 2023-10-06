using DemoASPMVC_DAL.Models;

namespace TechniNetGameAPI.Models
{
    public class GameView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre{ get; set; }
    }
}
