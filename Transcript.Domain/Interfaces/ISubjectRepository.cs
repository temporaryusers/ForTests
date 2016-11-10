using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transcript.Domain.Entities;

namespace Transcript.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> Subjects { get; }

        void Save();

        void Create(Subject subject);

        void Edit(Subject subject);

        void Delete(int id);
    }
}
