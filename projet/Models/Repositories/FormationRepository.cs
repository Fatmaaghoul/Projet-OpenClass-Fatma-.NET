using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models.Repositories
{
    public class FormationRepository : IFormationRepository
    {
        readonly ParticipantContext context;
        public FormationRepository(ParticipantContext context)
        {
            this.context = context;
        }
        public void Add(Formation s)
        {
            context.Formations.Add(s);
            context.SaveChanges();
        }

        public void Delete(Formation s)
        {
            Formation s1 = context.Formations.Find(s.FormationID);
            if (s1 != null)
            {
                context.Formations.Remove(s1);
                context.SaveChanges();
            }
        }

        public void Edit(Formation s)
        {
            Formation s1 = context.Formations.Find(s.FormationID);
            if (s1 != null)
            {
                s1.FormationName = s.FormationName;
                s1.FormationDate = s.FormationDate;
                s1.FormateurName = s.FormateurName;
                context.SaveChanges();
            }

        }

        public IList<Formation> GetAll()
        {
            return context.Formations.OrderBy(s => s.FormationName).ToList();
        }

        public Formation GetById(int id)
        {
            return context.Formations.Find(id);
        }

        public int ParticipantCount(int formationId)
        {
            return context.Participants.Where(s => s.FormationID == formationId).Count();
        }

        public double StudentAgeAverage(int formationId)
        {
            throw new NotImplementedException();
        }

        public int StudentCount(int formationId)
        {
            throw new NotImplementedException();
        }
    }
}
