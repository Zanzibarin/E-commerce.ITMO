using System;
using eTicketsNew.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using eTicketsNew.Data.Base;

namespace eTicketsNew.Models
{
    public class Play : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PlayCategory PlayCategory { get; set; }

        //Relationships
        public List<Actor_Play> Actors_Plays { get; set; }

        //Stage
        public int StageId { get; set; }
        [ForeignKey("StageId")]
        public Stage Stage { get; set; }

        //Director
        public int DirectorId { get; set; }
        [ForeignKey("DirectorId")]
        public Director Director { get; set; }
    }
}
