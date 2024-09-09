using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace WebApi.Models
{
    public class ReportModel
    {
        [Key]
        public int ReportId { get; set; }

        public string? ReasonOfReport { get; set; } 
        public string? AdminComment { get; set; }
        public string SendedReportUserId { get; set; } = null!;

        public string ReportedUserId { get; set; } = null!;

        public DateTime TimeReported { get; set; }
       
    }
}
