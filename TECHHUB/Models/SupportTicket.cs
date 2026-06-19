using System.ComponentModel.DataAnnotations;

namespace TECHHUB.Models
{
    public class SupportTicket
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a title for the issue log: ")]
        public required string IssueTitle { get; set; }

        [Required(ErrorMessage = "Describe the issue: ")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "How urgently this issue must be resolved: ")]
        public required string UrgencyLevel { get; set; }

        [Required(ErrorMessage = "Log creation date: ")]
        public required DateTime ReportedDate { get; set; }

        [Required(ErrorMessage = "Current ticket status: ")]
        public required string Status { get; set; } = "Open";
    }
}
