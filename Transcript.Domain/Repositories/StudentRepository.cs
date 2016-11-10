using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transcript.Domain.Context;
using Transcript.Domain.Entities;
using Transcript.Domain.Interfaces;

namespace Transcript.Domain.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Student> Students
        {
            get
            {
                return context.Students;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public void Create(Student student)
        {
            context.Students.Add(student);

            Save();
        }

        public void Edit(Student student)
        {
            context.Entry(student).State = EntityState.Modified;

            Save();
        }

        public void Delete(int id)
        {
            Student student = context.Students.Find(id);

            context.Students.Remove(student);

            Save();
        }
    }
}
