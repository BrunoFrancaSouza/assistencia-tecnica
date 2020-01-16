using AssistenciaTecnica.Domain;
using Microsoft.EntityFrameworkCore;

namespace AssistenciaTecnica.WebAPI.Data.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
        {
            // Configurações específicas para a tabela para a entidade "Usuario"
            // builder.HasKey(usuario => usuario.Id);
		    // builder.Property(usuario => usuario.Nome)
            //     .IsRequired()
            //     .HasColumnType("nvarchar(250)");
            // .HasDefaultValueSql("");

            // builder.HasOne(a => a.Empresa)
            //     .WithMany(u => u.Usuarios);

            builder.HasData(
                new Usuario {   Id = 1, UserName = "Bruno França Souza", Senha = "minhasenha1", Nome = "Bruno", Sobrenome = "França Souza", Email = "brunofrancasouza@gmail.com",
                                Perfil = "Admin", Ativo = true, AlteradoPor = "Sistema", empresaId = 1
                            }
            );

        }
    }
}