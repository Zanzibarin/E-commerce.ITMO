using System;
using eTicketsNew.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace eTicketsNew.Models
{
    public class Actor_Play
    {
        public int PlayId { get; set; }
        public Play Play { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
