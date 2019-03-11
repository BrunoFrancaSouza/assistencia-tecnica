using AssistenciaTecnica.Domain;
using Microsoft.EntityFrameworkCore;

namespace AssistenciaTecnica.WebAPI.Data.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
        {
            // Configurações específicas para a tabela para a entidade "Usuario"
            // builder.HasKey(usuario => usuario.UsuarioId);
		    // builder.Property(usuario => usuario.Nome)
            //     .IsRequired()
            //     .HasColumnType("nvarchar(250)");
            // .HasDefaultValueSql("");

        }
    }
}