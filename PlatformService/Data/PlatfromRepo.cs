using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatfromRepo : IPlatfromRepo
    {
        private readonly AppDbContext _context;

        public PlatfromRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePlatfrom(Platfrom platfrom)
        {
            if (platfrom == null)
            {
                throw new ArgumentNullException(nameof(platfrom));
            }
            _context.Platfroms.Add(platfrom);
        }

        public IEnumerable<Platfrom> GetAllPlatforms()
        {
            return _context.Platfroms.ToList();
        }

        public Platfrom GetPlatformById(int id)
        {
            return _context.Platfroms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0 );
        }
    }
}