using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string City { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("HomeTeam")]
        public int? HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        [ForeignKey("AwayTeam")]
        public int? AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public ICollection<Set> Sets { get; set; }
    }
}
