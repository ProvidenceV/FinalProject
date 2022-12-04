using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FinalProject.Models
{
    public partial class Game
    {
        [Key]
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Genre { get; set; }
        [StringLength(100)]
        public string Publisher { get; set; }
        [StringLength(100)]
        public string Platform { get; set; }
        [StringLength(100)]
        public string Mode { get; set; }
        [StringLength(100)]
        public string Person { get; set; }

        [ForeignKey(nameof(Person))]
        [InverseProperty("Games")]
        public virtual Person PersonNavigation { get; set; }
    }
}
