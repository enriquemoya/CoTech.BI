using Microsoft.EntityFrameworkCore;

namespace CoTech.Bi.Modules.Companies.Models
{
    public class CompanyRepository
    {
        private readonly BiContext context;
        private DbSet<CompanyEntity> db {
          get { return context.Set<CompanyEntity>(); }
        }

        public CompanyRepository(BiContext context)
        {
          this.context = context;
        }
    }
}