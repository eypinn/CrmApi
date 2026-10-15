using CrmApi.Data;
namespace CrmApi.Services;
public interface ISegmentService : IEntityService<Segment> { }
public sealed class SegmentService(AppDb db) : EntityService<Segment>(db), ISegmentService { }
