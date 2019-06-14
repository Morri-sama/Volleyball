using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Rally : ActionBase
    {
        /// <summary>
        /// Возможные варианты: "Выиграл", "Ввёл", "Проиграл".
        /// </summary>
        public override string Result { get; set; }

        public override string Name { get; set; }
        public override string Description { get; set; }

        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        public ICollection<ActionBase> Actions { get; set; }

    }
}
