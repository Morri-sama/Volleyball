using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Serve : ActionBase 
    {
        private string _result;
        private Player _player;
        private Player _playerReceiver;

        /// <summary>
        /// Возможные варианты: "Выиграл", "Ввёл", "Проиграл".
        /// </summary>
        public override string Result { get => _result; set => Notify(ref _result, value, "Result"); }

        [NotMapped]
        public List<string> ResultOptions { get; set; } = new List<string>() { "Выиграл", "Ввёл", "Проиграл" };

        public override string Name { get; set; } = "Подача";
        public override string Description { get; set; }

        [ForeignKey("Player")]
        public int? PlayerId { get; set; }
        public Player Player { get => _player; set => Notify(ref _player, value, "Name"); }

        [ForeignKey("PlayerReceiver")]
        public int? PlayerReceiverId { get; set; }
        public Player PlayerReceiver { get => _playerReceiver; set => Notify(ref _playerReceiver, value, "Name"); }
    }
}
