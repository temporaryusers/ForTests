using System.Collections.Generic;
using System.Data.Entity;
using Transcript.Domain.Context;
using Transcript.Domain.Entities;
using Transcript.Domain.Interfaces;

namespace Transcript.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<User> Users
        {
            get
            {
                return context.Users;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public void Create(User user)
        {
            context.Users.Add(user);

            Save();
        }

        public void Edit(User user)
        {
            context.Entry(user).State = EntityState.Modified;

            Save();
        }

        public void Delete(int id)
        {
            User user = context.Users.Find(id);

            context.Users.Remove(user);

            Save();
        }
    }
}
