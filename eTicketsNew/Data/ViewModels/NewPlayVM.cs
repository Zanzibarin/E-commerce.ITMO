using System;
using eTicketsNew.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using eTicketsNew.Data.Base;

namespace eTicketsNew.Models
{
    public class NewPlayVM
    {
        public int Id { get; set; }

        [Display(Name = "Название спектакля")]
        [Required(ErrorMessage = "Введите название!")]
        public string Name { get; set; }

        [Display(Name = "Описание спектакля")]
        [Required(ErrorMessage = "Введите описание!")]
        public string Description { get; set; }

        [Display(Name = "Стоимость билета")]
        [Required(ErrorMessage = "Введите стоимость!")]
        public double Price { get; set; }

        [Display(Name = "Афиша спектакля")]
        [Required(ErrorMessage = "Разместите сслку на изображение!")]
        public string ImageURL { get; set; }

        [Display(Name = "Дата начала показа")]
        [Required(ErrorMessage = "Введите дату!")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Дата окончания показа")]
        [Required(ErrorMessage = "Введите дату!")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Жанр")]
        [Required(ErrorMessage = "Укажите жанр!")]
        public PlayCategory PlayCategory { get; set; }


        //Relationships
        [Display(Name = "Список актёров")]
        [Required(ErrorMessage = "Укажите актёров!")]
        public List<int> ActorIds{ get; set; }

        [Display(Name = "Список площадок")]
        [Required(ErrorMessage = "Укажите площадку!")]
        public int StageId { get; set; }

        [Display(Name = "Список режиссёров")]
        [Required(ErrorMessage = "Укажите режиссёра!")]
        public int DirectorId { get; set; }
    }
}
