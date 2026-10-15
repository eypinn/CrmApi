using CrmApi.Data;
namespace CrmApi.Services;
public interface ICustomerService : IEntityService<Customer> { }
public sealed class CustomerService(AppDb db) : EntityService<Customer>(db), ICustomerService { }
