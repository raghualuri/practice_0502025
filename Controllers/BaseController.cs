using Microsoft.AspNetCore.Mvc;
using practice_0502025.Application.Interfaces; // For IGenericService
using System.Collections.Generic; // For IEnumerable
using System.Threading.Tasks; // For Task
using System; // For KeyNotFoundException

namespace practice_0502025.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TEntity,TEntityDto> : ControllerBase
        where TEntityDto : class
    {
        protected readonly IGenericService<TEntity,TEntityDto> _service;

        public BaseController(IGenericService< TEntity,TEntityDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntityDto>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntityDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<TEntityDto>> Create(TEntityDto dto)
        {
            var createdItem = await _service.CreateAsync(dto);
            var idProperty = createdItem.GetType().GetProperty("Id");
            if (idProperty == null || idProperty.PropertyType != typeof(int))
            {
                return Created(string.Empty, createdItem);
            }
            var idValue = (int)idProperty.GetValue(createdItem)!;

            return CreatedAtAction(nameof(GetById), new { id = idValue }, createdItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TEntityDto dto)
        {
            var idProperty = dto.GetType().GetProperty("Id");
            if (idProperty != null && (int)idProperty.GetValue(dto)! != id)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            try
            {
                await _service.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}