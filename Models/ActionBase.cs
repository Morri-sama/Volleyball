using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public abstract class ActionBase : PropertyChangedBase, INotifyPropertyChanged
    {
        private Player _player;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public abstract string Result { get; set; }

        public abstract string Name { get; set; }
        public abstract string Description { get;  }

        public int Index { get; set; }

        [NotMapped]
        public Team Team { get; set; }

        [ForeignKey("Player")]
        public int? PlayerId { get; set; }
        public Player Player { get => _player; set => Notify(ref _player, value, "Name"); }

        [ForeignKey("Rally")]
        public int? RallyId { get; set; }
        public Rally Rally { get; set; }
    }
}
