using MeepProducts.Data;
using MeepProducts.Interfaces;
using MeepProducts.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.Locais.Where(p => p.LocalId == id).FirstOrDefault();
        }

        public Local GetLocal(string name)
        {
            return _context.Locais.Where(p => p.Cidade == name).FirstOrDefault();
        }

        public ICollection<Local> GetLocals()
        {
            return _context.Locais.OrderBy(p => p.LocalId).ToList();

        }

        public bool LocalExists(int id)
        {
            return _context.Locais.Any(p => p.LocalId == id);
        }

        public bool ExistsByName(string name)
        {
            return _context.Locais.Any(p => p.Cidade == name);
        }
    }
}
 