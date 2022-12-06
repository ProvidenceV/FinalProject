using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using FinalProject.Models;

namespace FinalProject.Dtos
{
    public class PersonDto
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime? Birthdate { get; set; }

        [Required]
        public string CollegeProgram { get; set; }

        [Required]
        public string YearInProgram { get; set; }

        public static Person GetPerson(PersonDto person)
        {
            return new Person
            {
                FullName = person.FullName,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Birthdate = person.Birthdate,
                CollegeProgram = person.CollegeProgram,
                YearInProgram = person.YearInProgram,

            };
        }
    }
}
