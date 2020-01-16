using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistenciaTecnica.Domain;

namespace AssistenciaTecnica.Repository
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        //  Task<IEnumerable<IGrouping<string, List<Usuario>>>> GetUsuariosAtivosAgrupados();
         IEnumerable<UsuarioAgrupado> GetAtivosAgrupadosPorEmpresaSetor();
    }
}