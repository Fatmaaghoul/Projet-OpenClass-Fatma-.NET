using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models
{
    public class ParticipantContext : IdentityDbContext
    {
        public ParticipantContext(DbContextOptions<ParticipantContext> options) : base(options)
        {
        }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Formation> Formations { get; set; }

    }
}
