using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using OnlyMvc.BAL;
using OnlyMvc.Domain;
using OnlyMvc.Infrastructure;
using OnlyMvc.Models;

namespace OnlyMvc.DAL
{
    public class CurdRepository:ICurdRepository
    {
        private MyContext context;

        public CurdRepository(MyContext myContext)
        {
            this.context = myContext;
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<NewUser> GetAll()
        {
           return context.NewUsers.ToList().OrderByDescending(x=>x.CreateDate);
        }

        public void Create(NewUser user)
        {
            context.NewUsers.Add(user);
        }

        public void Update(NewUser user)
        {
            context.Entry(user).State=EntityState.Modified;
        }

        public NewUser GetById(int id)
        {
            return context.NewUsers.Find(id);
        }

        public void Delete(int id)
        {
            NewUser user = context.NewUsers.Find(id);
            context.NewUsers.Remove(user);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public bool IsExist(NewUserModel user)
        {
            return context.NewUsers.Any(x=>x.Email==user.Email);
        }
    }
}