using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transcript.Domain.Entities;

namespace Transcript.Domain.Interfaces
{
    public interface IFacultyRepository
    {
        IEnumerable<Faculty> Faculties { get; }

        void Save();

        void Create(Faculty faculty);

        void Edit(Faculty faculty);

        void Delete(int id);
    }
}
