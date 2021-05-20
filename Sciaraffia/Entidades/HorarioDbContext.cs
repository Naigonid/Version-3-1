using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Sciaraffia.Entidades{
    public class HorarioDbContext : DbContext{
        public DbSet<HorarioCita>  HorarioC {get; set;} 
        public DbSet<Usuario>  usuarioC {get; set;} 





        
        public HorarioDbContext(){

        }
        public HorarioDbContext(DbContextOptions options):base(options){

        }
    }
}