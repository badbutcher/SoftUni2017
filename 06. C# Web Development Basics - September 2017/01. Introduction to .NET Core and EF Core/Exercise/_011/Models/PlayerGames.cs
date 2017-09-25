namespace _011.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PlayerGames
    {
        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}