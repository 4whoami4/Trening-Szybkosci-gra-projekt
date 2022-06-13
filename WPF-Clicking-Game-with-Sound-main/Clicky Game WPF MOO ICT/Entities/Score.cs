using Microsoft.EntityFrameworkCore;

namespace Clicky_Game_WPF_MOO_ICT.Entities
{
    public class Score
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public string Nickname { get; set; }
    }
}
