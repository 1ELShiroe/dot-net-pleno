using System.Linq.Expressions;

using Model = StallosDotnetPleno.Domain.Models.Customer;

namespace StallosDotnetPleno.Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        public Model.Customer GetCustomer(Expression<Func<Model.Customer, bool>> expression);
        public Model.Customer Add(Model.Customer model);
        public int Update(Model.Customer model);
    }
}