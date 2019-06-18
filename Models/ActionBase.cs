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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public abstract string Result { get; set; }

        public abstract string Name { get; set; }
        public abstract string Description { get; set; }

        public int Index { get; set; }

        [ForeignKey("Rally")]
        public int? RallyId { get; set; }
        public Rally Rally { get; set; }
    }
}
