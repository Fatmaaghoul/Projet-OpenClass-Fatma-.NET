using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models.Repositories
{
    public interface IFormationRepository
    {
        IList<Formation> GetAll();
        Formation GetById(int id);
        void Add(Formation s);
        void Edit(Formation s);
        void Delete(Formation s);
        double StudentAgeAverage(int formationId);
        int ParticipantCount(int formationId);
    }
}
