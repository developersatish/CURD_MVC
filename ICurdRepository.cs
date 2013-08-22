using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlyMvc.Domain;
using OnlyMvc.Models;

namespace OnlyMvc.BAL
{
    public interface ICurdRepository : IDisposable
    {
        IEnumerable<NewUser> GetAll();
        void Create(NewUser user);
        void Update(NewUser user);
        NewUser GetById(int id);
        void Delete(int id);
        bool IsExist(NewUserModel user);
        void Save();
    }
}