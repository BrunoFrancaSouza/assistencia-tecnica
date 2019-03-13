using System;

namespace AssistenciaTecnica.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string AlteradoPor { get; set; }

        //Foreign key Empresa Standard
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}