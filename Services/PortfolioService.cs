using CrmApi.Data;
namespace CrmApi.Services;
public interface IPortfolioService : IEntityService<Portfolio> { }
public sealed class PortfolioService(AppDb db) : EntityService<Portfolio>(db), IPortfolioService { }
