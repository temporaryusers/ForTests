using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transcript.Domain.Entities;

namespace Transcript.Domain.Interfaces
{
    public interface IAbsenceRepository
    {
        IEnumerable<Absence> Absences { get; }

        void Save();

        void Create(Absence absence);

        void Edit(Absence absence);

        void Delete(int id);
    }
}
