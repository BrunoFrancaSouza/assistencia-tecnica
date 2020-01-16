using AssistenciaTecnica.Domain;
using Microsoft.EntityFrameworkCore;

namespace AssistenciaTecnica.Repository.EntitiesConfiguration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Empresa> builder)
        {
            // Configurações específicas para a tabela para a entidade "Usuario"
            
            builder.HasData(
                new Empresa {   Id = 1, RazaoSocial = "BFSOFTWARE", NomeFantasia = "BFSOFTWARE", Cnpj = "88.960.849/0001-58", Setor = "Serviços", Endereco = "Endereço 1",
                                Email = "Email 1", Telefone = "Telefone 1", Ativo = true, AlteradoPor = "Sistema"
                            }
            );

        }
        
    }
}