using System.Linq;
using AssistenciaTecnica.Domain;
using AssistenciaTecnica.WebAPI.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace AssistenciaTecnica.Repository
{
    public class AssistenciaTecnicaContext : DbContext
    {
        public AssistenciaTecnicaContext(DbContextOptions<AssistenciaTecnicaContext> options) : base (options) {}
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurações gerais para as tabelas das entidades (https://stackoverflow.com/questions/41468722/loop-reflect-through-all-properties-in-all-ef-models-to-set-column-type)
            foreach (var p in modelBuilder.Model
                    .GetEntityTypes()
                    .SelectMany(t => t.GetProperties())
                    .Where(p => 
                        p.ClrType == typeof(string)))
                        // ||
                        // p.ClrType == typeof(string?)))
                    {
                        p.SqlServer().ColumnType = "nvarchar(250)";
                    }

            
            //Configurações específicas de tabelas das entidades
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

            //Aplica alterações
            base.OnModelCreating(modelBuilder);
        }
    }
}