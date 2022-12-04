using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FinalProject.Models
{
    [Table("Pokemon")]
    public partial class Pokemon
    {
        [Key]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Type1 { get; set; }
        [StringLength(100)]
        public string Type2 { get; set; }
        [Required]
        [StringLength(100)]
        public string Ability { get; set; }
        [Column("Held Item")]
        [StringLength(100)]
        public string HeldItem { get; set; }
        public int? Level { get; set; }
        [Required]
        [StringLength(100)]
        public string Person { get; set; }

        [ForeignKey(nameof(Person))]
        [InverseProperty("Pokemons")]
        public virtual Person PersonNavigation { get; set; }
    }
}
