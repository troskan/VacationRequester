﻿using System.ComponentModel.DataAnnotations;

namespace VacationRequester.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public ApprovalState ApprovalState { get; set; }
    }
}
