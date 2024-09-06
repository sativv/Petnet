using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly ReportRepo _reportRepo;



        public ReportController(ReportRepo reportRepo)
        {
            _reportRepo = reportRepo;
        }



        // Get all reports
        [HttpGet]
        public async Task<IActionResult> GetAllReportsAsync()
        {
            List<ReportModel> allReports = await _reportRepo.GetAllReportsAsync();


            if (allReports == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(allReports);
            }
        }

        [HttpPost]
        // Make a report
        public async Task<IActionResult> AddReportAsync([FromBody] ReportModel reportModel)
        {
            if (reportModel == null)
            {
                return BadRequest();
            }

            var addedReport = await _reportRepo.AddReportModelAsync(reportModel);
            await _reportRepo.SaveChangesAsync(); 

            return Ok(addedReport);
        }



        //Remove report 

        [HttpDelete("RemoveReport/{id}")]
        public async Task<IActionResult> RemoveReportAsync(int id)
        {
            var reportToRemove = await _reportRepo.GetReportAsync(id);
            if (reportToRemove == null)
            {
                return NotFound();
            }

            _reportRepo.RemoveReportAsync(reportToRemove);
            await _reportRepo.SaveChangesAsync();

            return Ok();
        }



    }
}
