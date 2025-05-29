using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectAl1.Models.LeaveTypes
{
    //ReadOnly so this one model is used for both 'View' and 'Details' pages.
    public class LeaveTypeReadOnlyVM
    {
        public int LeaveTypeId { get; set; }

        [Display(Name="Leave Type")]
        public string LeaveTypeName { get; set; } = string.Empty;
        [Display(Name = "Days")]
        public int LeaveTypeNumberOfDays { get; set; }
    }
}
