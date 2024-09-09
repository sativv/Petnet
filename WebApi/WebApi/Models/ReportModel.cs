using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace WebApi.Models
{
    public class ReportModel
    {
        [Key]
        public int ReportId { get; set; }


        public string ReasonOfReport { get; set; } = null!;
        public string AdminComment { get; set; }
        public string SendedReportUserId { get; set; }

        public string ReportedUserId { get; set; }

  
   


        public DateTime TimeReported { get; set; }
       
    }
}
