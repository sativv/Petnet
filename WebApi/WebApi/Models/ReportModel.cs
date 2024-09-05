using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace WebApi.Models
{
    public class ReportModel
    {
        [Key]
        public int ReportId { get; set; }

        public string ReasonOfReport { get; set; } = null!;
        public int SendedReportUserId { get; set; }

        public int ReportedUserId { get; set; }
        public DateTime TimeReported { get; set; }
       
    }
}
