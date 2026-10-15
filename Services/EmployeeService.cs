using CrmApi.Data;
namespace CrmApi.Services;
public interface IEmployeeService : IEntityService<Employee> { }
public sealed class EmployeeService(AppDb db) : EntityService<Employee>(db), IEmployeeService { }
