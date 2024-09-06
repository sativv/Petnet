using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class ReportRepo
    {
        private readonly ApplicationDbContext _context;

        public ReportRepo(ApplicationDbContext context)
        {
            _context = context;
        }



        // Get one Report
        public async Task<ReportModel?> GetReportAsync(int id)
        {
            return await _context.Reports.FirstOrDefaultAsync(r => r.ReportId == id);
        }



        // Gets all Reports

        public async Task<List<ReportModel>> GetAllReportsAsync()
        {
            return await _context.Reports.ToListAsync();
        }


        //Make a report
        public async Task<ReportModel> AddReportModelAsync(ReportModel reportModelToAdd)
        {
            await _context.Reports.AddAsync(reportModelToAdd);
            return reportModelToAdd;
        }


        // Remove report 

        public void RemoveReportAsync(ReportModel reportToRemove)
        {

            _context.Reports.Remove(reportToRemove);
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
