using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Receive : ActionBase
    {
        /// <summary>
        /// Возможные варианты: "Позитивный", "Негативный".
        /// </summary>
        public override string Result { get; set; }

        [ForeignKey("Player")]
        public int? PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
