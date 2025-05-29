using System.ComponentModel.DataAnnotations;

namespace FinalProjectAl1.Models.LeaveTypes
{
    public class LeaveTypeCreateVM
    {
        [Required] //business rule for validation
        [Length(4,150, ErrorMessage ="You have exceeded the length requirement")] //business rule for validation
        [Display(Name = "Leave Type")]
        public string LeaveTypeName { get; set; } = string.Empty;
        [Required] //business rule for validation
        [Range(1, 90)] //business rule for validation
        [Display(Name = "Days")]
        public int LeaveTypeNumberOfDays { get; set; }
    }
}
