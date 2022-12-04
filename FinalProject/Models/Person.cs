using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FinalProject.Models
{
    [Table("Person")]
    public partial class Person
    {
        public Person()
        {
            Champions = new HashSet<Champion>();
            Games = new HashSet<Game>();
            Pokemons = new HashSet<Pokemon>();
        }

        [Key]
        [Column("Full Name")]
        [StringLength(100)]
        public string FullName { get; set; }
        [Column("First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Column("Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Birthdate { get; set; }
        [Column("College Program")]
        [StringLength(100)]
        public string CollegeProgram { get; set; }
        [Column("Year in Program")]
        [StringLength(100)]
        public string YearInProgram { get; set; }

        [InverseProperty(nameof(Champion.PersonNavigation))]
        public virtual ICollection<Champion> Champions { get; set; }
        [InverseProperty(nameof(Game.PersonNavigation))]
        public virtual ICollection<Game> Games { get; set; }
        [InverseProperty(nameof(Pokemon.PersonNavigation))]
        public virtual ICollection<Pokemon> Pokemons { get; set; }
    }
}
