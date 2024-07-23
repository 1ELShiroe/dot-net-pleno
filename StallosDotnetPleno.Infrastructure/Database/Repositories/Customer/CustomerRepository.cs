using StallosDotnetPleno.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AutoMapper;

using Model = StallosDotnetPleno.Domain.Models.Customer;
using Entity = StallosDotnetPleno.Infrastructure.Database.Entities.Customer;

namespace StallosDotnetPleno.Infrastructure.Database.Repositories.Customer
{
    public class CustomerRepository(IMapper Mapper) : ICustomerRepository
    {
        public Model.Customer GetCustomer(Expression<Func<Model.Customer, bool>> expression)
        {
            using var context = new Context();
            var predicate = Mapper.Map<Expression<Func<Entity.Customer, bool>>>(expression);
            var entities = context.Customers.Include(c => c.Addresses).FirstOrDefault(predicate);

            return Mapper.Map<Model.Customer>(entities);
        }

        public Model.Customer Add(Model.Customer model)
        {
            using var context = new Context();

            var entity = Mapper.Map<Entity.Customer>(model);

            context.Customers.Add(entity);
            context.SaveChanges();

            return Mapper.Map<Model.Customer>(entity);
        }

        public int Update(Model.Customer model)
        {
            using var context = new Context();
            var entity = Mapper.Map<Entity.Customer>(model);

            context.Customers.Update(entity);

            return context.SaveChanges();
        }

        public int Remove(Model.Customer model)
        {
            using var context = new Context();
            var entity = Mapper.Map<Entity.Customer>(model);

            context.Customers.Remove(entity);

            return context.SaveChanges();
        }
    }
}