using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class KickOff : Action
    {
        public override string ActionName { get; set; } = "KickOff";

        public string Result { get; set; }

        [ForeignKey("Player")]
        public int? PlayerId { get; set; }
        public Player Player { get; set; }

    }
}
