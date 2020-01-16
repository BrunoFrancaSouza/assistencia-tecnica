using System.Linq;
using AssistenciaTecnica.Domain;
using AssistenciaTecnica.Domain.Identity;
using AssistenciaTecnica.Repository.EntitiesConfiguration;
using AssistenciaTecnica.WebAPI.Data.EntitiesConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AssistenciaTecnica.Repository
{
    public class AssistenciaTecnicaContext : IdentityDbContext<User, Role, int, 
                                                                IdentityUserClaim<int>, UserRole, 
                                                                IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
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
                        p.SqlServer().ColumnType = "nvarchar(150)";
                    }

             
            //Configurações específicas de tabelas das entidades
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());

            //Aplica alterações
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole => 
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId});

                userRole.HasOne(ur => ur.role)
                    .WithMany(r => r.userRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.user)
                    .WithMany(r => r.Roles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}