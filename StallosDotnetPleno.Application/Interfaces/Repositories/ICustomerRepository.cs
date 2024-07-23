using StallosDotnetPleno.Domain.Models.Customer;
using System.Linq.Expressions;

namespace StallosDotnetPleno.Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        public CustomerModel GetCustomer(Expression<Func<CustomerModel, bool>> expression);
        public List<CustomerModel> GetCustomers(Expression<Func<CustomerModel, bool>> expression);
        public CustomerModel Add(CustomerModel model);
        public int Remove(CustomerModel model);
        public int Update(CustomerModel model);
    }
}