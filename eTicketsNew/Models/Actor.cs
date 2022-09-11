using eTicketsNew.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTicketsNew.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Фото")]
        [Required(ErrorMessage ="Разместите фото")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "ФИО")]
        [Required(ErrorMessage = "Укажите ФИО")]
        [StringLength(100, MinimumLength =10, ErrorMessage = "ФИО не короче 3-х, и не длиннее 100 символов!")]
        public string FullName { get; set; }

        [Display(Name = "Биография")]
        [Required(ErrorMessage = "Разместите биографию")]
        public string Bio { get; set; }
        
        //Relationships
        public List<Actor_Play> Actors_Plays { get; set; }
    }
}
