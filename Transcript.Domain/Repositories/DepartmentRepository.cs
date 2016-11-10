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
    public class DepartmentRepository : IDepartmentRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Department> Departments
        {
            get
            {
                return context.Departments;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Create(Department department)
        {
            context.Departments.Add(department);

            Save();
        }

        public void Edit(Department department)
        {
            context.Entry(department).State = EntityState.Modified;

            Save();
        }

        public void Delete(int id)
        {
            Department department = context.Departments.Find(id);

            context.Departments.Remove(department);

            Save();
        }
    }
}
