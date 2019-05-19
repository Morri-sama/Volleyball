using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public abstract class Action
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public abstract string ActionName { get; set; }

        public int Index { get; set; }

        [ForeignKey("Rally")]
        public int RallyId { get; set; }
        public Rally Rally { get; set; }
    }
}
