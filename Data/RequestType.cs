using System.ComponentModel.DataAnnotations;

namespace FinalProjectAl1.Data
{
    public class RequestType
    {
        [Key]
        public Guid Request_TaskId { get; set; } = Guid.NewGuid();
        public DateTime Request_DateTime { get; set; }
        [Required]
        [StringLength(50)]
        public string Request_FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string Request_LastName { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Request_EmailAdd { get; set; }
        [Required]
        [StringLength(50)]
        public string Request_TeamSelect { get; set; }
        public string Request_TaskDescription { get; set; }

    }
}
