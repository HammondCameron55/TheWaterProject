
namespace TheWaterProject.Models
{
    public class EFWaterRepository : IWaterRepository
    {
        private WaterProjectContext _context;
        public EFWaterRepository(WaterProjectContext ctx)
        {
            _context = ctx;
        }
        public IQueryable<Project> Projects => _context.Projects;
    }
}
