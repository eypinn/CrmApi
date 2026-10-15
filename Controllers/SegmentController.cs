using Microsoft.AspNetCore.Mvc;
using CrmApi.Data;
using CrmApi.Services;
namespace CrmApi.Controllers;
[ApiController, Route("api/segments")]
public sealed class SegmentController(ISegmentService service) : ControllerBase {
 [HttpGet] public async Task<IActionResult> List(CancellationToken ct) => Ok(await service.ListAsync(ct));
 [HttpGet("{id}")] public async Task<IActionResult> Get(string id,CancellationToken ct) {
  var item=await service.GetAsync(new object[]{id},ct);
  return item is null ? NotFound() : Ok(item);
 }
 [HttpPost] public async Task<IActionResult> Create([FromBody] Segment item,CancellationToken ct) => Ok(await service.CreateAsync(item,ct));
 [HttpPut("{id}")] public async Task<IActionResult> Update(string id,[FromBody] Segment item,CancellationToken ct) {
  if(id != item.SegmentCode)return BadRequest("Route id and body key differ.");
  return await service.UpdateAsync(new object[]{id},item,ct) ? NoContent() : NotFound();
 }
 [HttpDelete("{id}")] public async Task<IActionResult> Delete(string id,CancellationToken ct) =>
  await service.DeleteAsync(new object[]{id},ct) ? NoContent() : NotFound();
}
