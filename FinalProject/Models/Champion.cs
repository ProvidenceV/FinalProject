using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FinalProject.Models
{
    [Table("Champion")]
    public partial class Champion
    {
        [Key]
        [StringLength(100)]
        public string ChampionName { get; set; }
        [StringLength(100)]
        public string Role { get; set; }
        [StringLength(100)]
        public string Class { get; set; }
        [StringLength(100)]
        public string Winrate { get; set; }
        [StringLength(100)]
        public string Item1 { get; set; }
        [StringLength(100)]
        public string Item2 { get; set; }
        [StringLength(100)]
        public string Item3 { get; set; }
        [StringLength(100)]
        public string Item4 { get; set; }
        [StringLength(100)]
        public string Item5 { get; set; }
        [StringLength(100)]
        public string Item6 { get; set; }
        [StringLength(100)]
        public string Person { get; set; }

        [ForeignKey(nameof(Person))]
        [InverseProperty("Champions")]
        public virtual Person PersonNavigation { get; set; }
    }
}
