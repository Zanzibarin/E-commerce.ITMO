using eTicketsNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsNew.Data.ViewModels
{
    public class NewPlayDropdownsVM
    {
        public NewPlayDropdownsVM()
        {
            Directors = new List<Director>();
            Stages = new List<Stage>();
            Actors = new List<Actor>();
        }

        public List<Director> Directors { get; set; }
        public List<Stage> Stages { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
