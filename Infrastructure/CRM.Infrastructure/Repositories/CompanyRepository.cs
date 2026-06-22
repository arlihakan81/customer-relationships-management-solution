using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;

namespace CRM.Infrastructure.Repositories
{
    public class CompanyRepository(AppDbContext context) : Repository<Company>(context), ICompanyRepository
    {


    }
}
