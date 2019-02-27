using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularTest.Models
{
    public class GameViewModel
    {
        public int ID { get; set; }
        [MinLength(1)]
        public string Name { get; set; }
        public string Developer { get; set; }
       
        public int Year { get; set; }
        public int YearsPast { get; set; }
    }
}
