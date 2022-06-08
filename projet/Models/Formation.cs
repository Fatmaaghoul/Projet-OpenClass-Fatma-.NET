using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models
{
    public class Formation
    {

        public int FormationID { get; set; }
        public string FormationName { get; set; }
        public string FormateurName { get; set; }

        [DataType(DataType.Date)]
        public DateTime FormationDate { get; set; }
        public ICollection<Participant> Participants { get; set; }
        }
    }

