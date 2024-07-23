using StallosDotnetPleno.Infrastructure.Database.Entities.Customer;
using StallosDotnetPleno.Application.Interfaces.Repositories;
using StallosDotnetPleno.Domain.Models.Customer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AutoMapper;


namespace StallosDotnetPleno.Infrastructure.Database.Repositories.Customer
{
    public class CustomerRepository(IMapper Mapper) : ICustomerRepository
    {
        public CustomerModel GetCustomer(Expression<Func<CustomerModel, bool>> expression)
        {
            using var context = new Context();
            var predicate = Mapper.Map<Expression<Func<CustomerEntity, bool>>>(expression);
            var entities = context.Customers.Include(c => c.Addresses).FirstOrDefault(predicate);

            return Mapper.Map<CustomerModel>(entities);
        }

        public List<CustomerModel> GetCustomers(Expression<Func<CustomerModel, bool>> expression)
        {
            using var context = new Context();
            var predicate = Mapper.Map<Expression<Func<CustomerEntity, bool>>>(expression);
            var entities = context.Customers
                .Include(c => c.Addresses)
                .Where(predicate)
                .ToList();

            return Mapper.Map<List<CustomerModel>>(entities);
        }

        public CustomerModel Add(CustomerModel model)
        {
            using var context = new Context();

            var entity = Mapper.Map<CustomerEntity>(model);

            context.Customers.Add(entity);
            context.SaveChanges();

            return Mapper.Map<CustomerModel>(entity);
        }

        public int Update(CustomerModel model)
        {
            using var context = new Context();
            var entity = Mapper.Map<CustomerEntity>(model);

            context.Customers.Update(entity);

            return context.SaveChanges();
        }

        public int UpdateRange(List<CustomerModel> models)
        {
            using var context = new Context();
            var entities = Mapper.Map<List<CustomerEntity>>(models);

            context.Customers.UpdateRange(entities);

            return context.SaveChanges();
        }

        public int Remove(CustomerModel model)
        {
            using var context = new Context();
            var entity = Mapper.Map<CustomerEntity>(model);

            context.Customers.Remove(entity);

            return context.SaveChanges();
        }
    }
}