using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectAl1.Data
{
    public class LeaveType
    {
        //Pascal Case for EF Framework. Qualified properties for ease of XXXXX
        public int LeaveTypeId { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string LeaveTypeName { get; set; } = string.Empty;
        public int LeaveTypeNumberOfDays { get; set; }
    }
}
