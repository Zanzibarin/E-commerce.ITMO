using eTicketsNew.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTicketsNew.Models
{
    public class Director : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Фото")]
        [Required(ErrorMessage = "Разместите фото")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "ФИО")]
        [Required(ErrorMessage = "Укажите ФИО")]
        public string FullName { get; set; }

        [Display(Name = "Биография")]
        [Required(ErrorMessage = "Разместите биографию")]
        public string Bio { get; set; }

        //Relationships
        public List<Play> Plays { get; set; }
    }
}
