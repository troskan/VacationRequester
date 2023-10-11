using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VacationRequester.Models;
using VacationRequester.Repositories.Interfaces;

namespace VacationRequester.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IRepository<LeaveType> _leaveTypeRepository;

        public LeaveTypeController(IRepository<LeaveType> leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();
            if (leaveTypes == null || !leaveTypes.Any())
            {
                return NotFound();
            }
            return Ok(leaveTypes);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            return Ok(leaveType);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(LeaveType leaveTypeToCreate)
        {
            if (leaveTypeToCreate == null)
            {
                return BadRequest();
            }
            await _leaveTypeRepository.AddAsync(leaveTypeToCreate);
            return CreatedAtAction(nameof(GetById), new { id = leaveTypeToCreate.Id }, leaveTypeToCreate);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, LeaveType leaveTypeToUpdate)
        {
            if (leaveTypeToUpdate == null || id != leaveTypeToUpdate.Id)
            {
                return BadRequest();
            }
            var existingLeaveType = await _leaveTypeRepository.GetByIdAsync(id);
            if (existingLeaveType == null)
            {
                return NotFound();
            }

            existingLeaveType.Type = leaveTypeToUpdate.Type;

            await _leaveTypeRepository.UpdateAsync(existingLeaveType);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(id);

            if (leaveTypeToDelete == null)
            {
                return NotFound();
            }

            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
            return Ok();
        }
    }
}
