using Microsoft.AspNetCore.Mvc;
using System.Collections;
using VacationRequester.Models;
using VacationRequester.Repositories.Interfaces;

namespace VacationRequester.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IRepository<LeaveType> _leaveTypeRepository;

        public LeaveTypeController(IRepository<LeaveType> leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _leaveTypeRepository.GetAllAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            LeaveType leaveType = await _leaveTypeRepository.GetByIdAsync(Id);
            return Ok(leaveType);
        }
        [HttpPost]
        public async Task Create(LeaveType leaveTypeToCreate)
        {
            await _leaveTypeRepository.AddAsync(leaveTypeToCreate);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return BadRequest();
            }
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(id);

            if (leaveTypeToDelete == null)
            {
                return BadRequest();
            }

            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
            return Ok();
        }
    }
}