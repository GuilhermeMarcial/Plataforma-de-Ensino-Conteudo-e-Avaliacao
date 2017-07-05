using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Identity.Models;

namespace PlataformaDeEnsino.Core.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>, IDisposable
    {
        public AppIdentityDbContext() 
        {  
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= ../../../../ConteudoDatabase.db");
        }
    }
}