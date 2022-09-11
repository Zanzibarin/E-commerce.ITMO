using eTicketsNew.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTicketsNew.Models
{
    public class Stage : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Логотип театра")]
        [Required(ErrorMessage = "Разместите логотип")]
        public string Logo { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Напишите название площадки")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Требуется информация о площадке")]
        public string Description { get; set; }

        //Relationships
        public List<Play> Plays { get; set; }
    }
}
