using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VacationRequester.Models;
using VacationRequester.Repositories.Interfaces;

namespace VacationRequester.Controllers;
[ApiController]
[Route("[Controller]")]
public class LeaveRequestController : ControllerBase
{
    private readonly IRepository<LeaveRequest> _repository;

    public LeaveRequestController(IRepository<LeaveRequest> repository)
    {
        _repository = repository;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var leaveRequests = await _repository.GetAllAsync();

        if (leaveRequests == null || !leaveRequests.Any())
        {
            return NotFound();
        }

        return Ok(leaveRequests);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        if (Id == Guid.Empty)
        {
            return null;
        }

        LeaveRequest leaveRequest = await _repository.GetByIdAsync(Id);

        if (leaveRequest == null)
        {
            return NotFound();
        }

        return Ok(leaveRequest);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(LeaveRequest leaveRequestToCreate)
    {
        if(leaveRequestToCreate == null)
        {
            return BadRequest();
        }

        await _repository.AddAsync(leaveRequestToCreate);
        return CreatedAtAction(nameof(Create), leaveRequestToCreate.Id);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, EditLeaveRequestDto leaveRequestToUpdateDto)
    {
        if (leaveRequestToUpdateDto == null || id != leaveRequestToUpdateDto.Id)
        {
            return BadRequest();
        }

        var existingLeaveRequest = await _repository.GetByIdAsync(id);

        if (existingLeaveRequest == null)
        {
            return NotFound();
        }

        // Mapping from DTO to the actual LeaveRequest entity
        existingLeaveRequest.UserId = leaveRequestToUpdateDto.UserId;
        existingLeaveRequest.LeaveTypeId = leaveRequestToUpdateDto.LeaveTypeId;
        existingLeaveRequest.StartDate = leaveRequestToUpdateDto.StartDate;
        existingLeaveRequest.EndDate = leaveRequestToUpdateDto.EndDate;
        existingLeaveRequest.DateRequested = leaveRequestToUpdateDto.DateRequested;
        existingLeaveRequest.ApprovalState = leaveRequestToUpdateDto.ApprovalState;

        await _repository.UpdateAsync(existingLeaveRequest);
        return NoContent();
    }

    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest();
        }

        var leaveRequestToDelete = await _repository.GetByIdAsync(id);

        if (leaveRequestToDelete == null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(leaveRequestToDelete);
        return Ok();
    }
}
