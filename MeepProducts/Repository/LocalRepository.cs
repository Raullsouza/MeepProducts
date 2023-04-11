using MeepProducts.Data;
using MeepProducts.Interfaces;
using MeepProducts.Models;

namespace MeepProducts.Repository
{
    public class LocalRepository : ILocalRepository
    {
        private readonly DataContext _context;

        public LocalRepository(DataContext context) 
        {
            _context = context;
        }
        public ICollection<Local> GetLocals()
        {
            return _context.Locais.OrderBy(p => p.Id).ToList();
        }
    }
}
 