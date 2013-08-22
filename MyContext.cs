using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OnlyMvc.Domain;
using OnlyMvc.Models;

namespace OnlyMvc.Infrastructure
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("myCon")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<NewUser> NewUsers { get; set; }
    }
}