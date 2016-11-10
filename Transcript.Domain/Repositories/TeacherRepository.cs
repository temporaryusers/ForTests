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
    public class TeacherRepository : ITeacherRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<UniversityTeacher> Teachers
        {
            get
            {
                return context.Teachers;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public void Create(UniversityTeacher teacher)
        {
            context.Teachers.Add(teacher);

            Save();
        }

        public void Edit(UniversityTeacher teacher)
        {
            context.Entry(teacher).State = EntityState.Modified;

            Save();
        }

        public void Delete(int id)
        {
            UniversityTeacher teacher = context.Teachers.Find(id);

            context.Teachers.Remove(teacher);

            Save();
        }
    }
}
