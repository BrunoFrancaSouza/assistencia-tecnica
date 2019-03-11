using System.Threading.Tasks;

namespace AssistenciaTecnica.Repository
{
    public class AssistenciaTecnicaRepository : IAssistenciaTecnicaRepository
    {
        public AssistenciaTecnicaContext _context { get; }

        public AssistenciaTecnicaRepository(AssistenciaTecnicaContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
             _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
             return (await _context.SaveChangesAsync()) > 0; // Se maior que zero (salvou alguma informação de alguma entidade alterada), retorna true
        }

        
    }
}