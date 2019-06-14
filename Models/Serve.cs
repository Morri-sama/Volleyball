﻿using System;
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

        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [ForeignKey("Player")]
        public int? PlayerId { get; set; }
        public Player Player { get; set; }

    }
}