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
    public class GroupRepository : IGroupRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<GroupStudent> Groups
        {
            get
            {
                return context.Groups;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public void Create(GroupStudent group)
        {
            context.Groups.Add(group);

            Save();
        }

        public void Edit(GroupStudent group)
        {
            context.Entry(group).State = EntityState.Modified;

            Save();
        }

        public void Delete(int id)
        {
            GroupStudent group = context.Groups.Find(id);

            context.Groups.Remove(group);

            Save();
        }
    }
}
