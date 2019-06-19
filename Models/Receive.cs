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

        [NotMapped]
        public List<string> ResultOptions { get; set; } = new List<string>() { "Позитивный", "Негативный"};

        public override string Name { get; set; }
        public override string Description { get; }
    }
}
