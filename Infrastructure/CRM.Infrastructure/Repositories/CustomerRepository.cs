using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;

namespace CRM.Infrastructure.Repositories
{
    public class CustomerRepository(AppDbContext context) : Repository<Customer>(context), ICustomerRepository
    {


    }
}
