using System;
using System.Collections.Generic;

namespace AssistenciaTecnica.Domain
{
    public class Empresa
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Setor { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string AlteradoPor { get; set; }
    
        public ICollection<Usuario> Usuarios { get; set; }
    }



}