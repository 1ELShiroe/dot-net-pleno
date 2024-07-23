namespace StallosDotnetPleno.Infrastructure.Database.Entities.Customer
{
    public class CustomerAddressEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? ZipCode { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? UF { get; set; }

        public virtual CustomerEntity? Customer { get; set; }
    }
}