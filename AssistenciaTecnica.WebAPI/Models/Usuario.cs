using System.ComponentModel.DataAnnotations;

namespace AssistenciaTecnica.WebAPI.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required]
        public string UserName { get; set; }
         [Required]
        public string Senha { get; set; }
         [Required]
        public string Nome { get; set; }
         [Required]
        public string Sobrenome { get; set; }
         [Required]
        public string Empresa { get; set; }
         [Required]
        public string Email { get; set; }
         [Required]
        public string Perfil { get; set; }
         [Required]
        public bool Ativo { get; set; }
         [Required]
        public string DataAlteracao { get; set; }
         [Required]
        public string AlteradoPor { get; set; }
    }
}