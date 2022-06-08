using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models.Repositories
{
    public interface IParticipantRepository
    {
        IList<Participant> GetAll();
        Participant GetById(int id);
        void Add(Participant s);
        void Edit(Participant s);
        void Delete(Participant s);
        IList<Participant> GetParticipantsByFormationID(int? formationId);
        IList<Participant> FindByName(string name);
    }
}
