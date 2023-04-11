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

        public Local GetLocal(int id)
        {
            return _context.Locais.Where(p => p.Id == id).FirstOrDefault();
        }

        public Local GetLocal(string name)
        {
            throw new NotImplementedException();
        }

        public ICollection<Local> GetLocals()
        {
            return _context.Locais.OrderBy(p => p.Id).ToList();
        }

        public bool LocalAtivo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
 