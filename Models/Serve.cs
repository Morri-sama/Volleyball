using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Serve : ActionBase
    {
        /// <summary>
        /// Возможные варианты: "Выиграл", "Ввёл", "Проиграл".
        /// </summary>
        public override string Result { get; set; }

        [NotMapped]
        public List<string> ResultOptions { get; set; } = new List<string>() { "Выиграл", "Ввёл", "Проиграл" };

        public override string Name { get; set; } = "Подача";
        public override string Description { get; set; }

        [ForeignKey("Player")]
        public int? PlayerId { get; set; }
        public Player Player { get; set; }

        [ForeignKey("PlayerReceiver")]
        public int? PlayerReceiverId { get; set; }
        public Player PlayerReceiver { get; set; }
    }
}
