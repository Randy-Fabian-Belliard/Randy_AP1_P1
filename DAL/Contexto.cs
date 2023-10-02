using Microsoft.EntityFrameworkCore;

namespace Randy_AP1_P1{

    public class Contexto: DbContext{
      public DbSet<Aportes> Aportes { get; set; }
      public Contexto(DbContextOptions<Contexto> options) : base (options)
      {

      }   
    }
}

