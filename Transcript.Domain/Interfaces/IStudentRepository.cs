using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transcript.Domain.Entities;

namespace Transcript.Domain.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> Students { get; }

        void Save();

        void Create(Student student);

        void Edit(Student student);

        void Delete(int id);
    }
}
