using ReportAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.Infrastructure
{
    public interface IReportService
    {
        Task<Report> CreateReportAsync(ReportRequest request);
        Task<IEnumerable<Report>> GetReportsAsync();
        Task<Report> GetReportByIdAsync(string id);
    }
}
