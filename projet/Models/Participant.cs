using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        [Required]
        public string ParticipantName { get; set; }
        public int ParticipantNum { get; set; }
        public int FormationID { get; set; }
        public Formation Formation { get; set; }
    }
}
