using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportAPI.Infrastructure;
using ReportAPI.Models;

namespace ReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IReportQueue _reportQueue;

        public ReportsController(IReportService reportService, IReportQueue reportQueue)
        {
            _reportService = reportService;
            _reportQueue = reportQueue;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReportAsync(ReportRequest request)
        {
            var report = await _reportService.CreateReportAsync(request);
            return Ok(report);
        }

        [HttpGet]
        public async Task<IActionResult> GetReportsAsync()
        {
            var reports = await _reportService.GetReportsAsync();
            return Ok(reports);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportByIdAsync(string id)
        {
            var report = await _reportService.GetReportByIdAsync(id);
            if (report == null)
                return NotFound();

            return Ok(report);
        }

        [HttpPost("enqueue")]
        public async Task<IActionResult> EnqueueReportAsync(ReportRequest request)
        {
            await _reportQueue.EnqueueReportAsync(request);
            return Ok();
        }
    }
}
