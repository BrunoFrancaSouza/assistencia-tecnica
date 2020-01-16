using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistenciaTecnica.Domain;
using Microsoft.EntityFrameworkCore;

namespace AssistenciaTecnica.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AssistenciaTecnicaContext context) : base(context) { }

        // public async Task<Usuario[]> GetUsuariosAtivosAgrupados()
        // public async Task<IEnumerable<IGrouping<string, List<Usuario>>>> GetUsuariosAtivosAgrupados()
        // {
        //     var query = _context.Set<Usuario>().Where(usuario => usuario.Ativo == true).GroupBy(usuario => new {usuario.Empresa.NomeFantasia, usuario.Setor, usuario.Nome, usuario.UserName}); 
            
        //     // return _context.Set<Usuario>().FirstOrDefaultAsync(usuario => usuario.Name == name);
        //     return await query.ToArrayAsync();
        // }

        public IEnumerable<UsuarioAgrupado> GetAtivosAgrupadosPorEmpresaSetor()
        {
            var query = _context.Set<Usuario>().Where(usuario => usuario.Ativo == true);
            var result = query.OrderBy(x => x.Empresa.NomeFantasia)
                                            .GroupBy(usuario => new {usuario.Empresa.NomeFantasia, usuario.Setor, usuario.Nome, usuario.UserName})
                                            .Select(x => new UsuarioAgrupado {Empresa  = x.Key.NomeFantasia, Setor  = x.Key.Setor, Nome = x.Key.Nome, Username = x.Key.UserName})
                                            .ToList();

            return result;
        }

    }
    
    public class UsuarioAgrupado 
    {
        public string Empresa {get; set; }
        public string Setor {get; set; }
        public string Nome {get; set; }
        public string Username {get; set; }
    }
}