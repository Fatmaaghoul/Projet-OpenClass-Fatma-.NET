using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        readonly ParticipantContext context;
        public ParticipantRepository(ParticipantContext context)
        {
            this.context = context;
        }

        public void Add(Participant s)
        {
            context.Participants.Add(s);
            context.SaveChanges();

        }

        public void Delete(Participant s)
        {
            Participant s1 = context.Participants.Find(s.ParticipantId);
            if (s1 != null)
            {
                context.Participants.Remove(s1);
                context.SaveChanges();
            }
        }

        public void Edit(Participant s)
        {
            Participant s1 = context.Participants.Find(s.ParticipantId);
            if (s1 != null)
            {
                s1.ParticipantName = s.ParticipantName;
                s1.ParticipantNum = s.ParticipantNum;
                s1.FormationID = s.FormationID;
                context.SaveChanges();

            }
        }

        public IList<Participant> FindByName(string name)
        {
            return context.Participants.Where(s => s.ParticipantName.Contains(name)).Include(std => std.Formation).ToList();
        }

        public IList<Participant> GetAll()
        {
            return context.Participants.OrderBy(x => x.ParticipantName).Include(x => x.Formation).ToList();
        }

        public Participant GetById(int id)
        {
            return context.Participants.Where(x => x.ParticipantId == id).Include(x => x.Formation).SingleOrDefault();

        }

        public IList<Participant> GetParticipantsByFormationID(int? formationId)
        {
            throw new NotImplementedException();
        }

        public IList<Participant> GetStudentsBySchoolID(int? schoolId)
        {
            return context.Participants.Where(s => s.FormationID.Equals(schoolId)).OrderBy(s => s.ParticipantName).Include(std => std.Formation).ToList();

        }
    }
}
