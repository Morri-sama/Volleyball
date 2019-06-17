using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Rally
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        public ICollection<ActionBase> Actions { get; set; }
    }
}
