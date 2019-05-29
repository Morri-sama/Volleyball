using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class KickOff : Action
    {
        /// <summary>
        /// Возможные варианты: "Выиграл", "Ввёл", "Проиграл"
        /// </summary>
        public override string Result { get; set; }

        [ForeignKey("Player")]
        public int? PlayerId { get; set; }
        public Player Player { get; set; }

        //[ForeignKey("SubmittedPlayer")]
        //public int? SubmittedPlayerId { get; set; }
        //public Player SubmittedPlayer { get; set; }
    }
}
