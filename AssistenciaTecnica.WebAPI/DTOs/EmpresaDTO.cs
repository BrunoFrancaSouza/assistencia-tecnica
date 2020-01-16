using System.Collections.Generic;

namespace AssistenciaTecnica.WebAPI.DTOs
{
    public class EmpresaDTO
    {
        // public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Setor { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public string DataAlteracao { get; set; }
        public string AlteradoPor { get; set; }
    
        public ICollection<UsuarioDTO> Usuarios { get; set; }
    }
}