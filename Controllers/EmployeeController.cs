using Microsoft.AspNetCore.Mvc;
using CrmApi.Data;
using CrmApi.Services;
namespace CrmApi.Controllers;
[ApiController, Route("api/employees")]
public sealed class EmployeeController(IEmployeeService service) : ControllerBase {
 [HttpGet] public async Task<IActionResult> List(CancellationToken ct) => Ok(await service.ListAsync(ct));
 [HttpGet("{id}")] public async Task<IActionResult> Get(string id,CancellationToken ct) {
  var item=await service.GetAsync(new object[]{id},ct);
  return item is null ? NotFound() : Ok(item);
 }
 [HttpPost] public async Task<IActionResult> Create([FromBody] Employee item,CancellationToken ct) => Ok(await service.CreateAsync(item,ct));
 [HttpPut("{id}")] public async Task<IActionResult> Update(string id,[FromBody] Employee item,CancellationToken ct) {
  if(id != item.EmployeeCode)return BadRequest("Route id and body key differ.");
  return await service.UpdateAsync(new object[]{id},item,ct) ? NoContent() : NotFound();
 }
 [HttpDelete("{id}")] public async Task<IActionResult> Delete(string id,CancellationToken ct) =>
  await service.DeleteAsync(new object[]{id},ct) ? NoContent() : NotFound();
}
