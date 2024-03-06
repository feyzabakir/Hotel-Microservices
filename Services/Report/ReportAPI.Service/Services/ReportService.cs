using MongoDB.Bson;
using MongoDB.Driver;
using ReportAPI.Infrastructure;
using ReportAPI.Models;
using ReportAPI.Service.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReportAPI.Models.Report;

namespace ReportAPI.Service.Services
{
    public class ReportService : IReportService
    {
        private readonly IMongoCollection<Report> _reportCollection;

        public ReportService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _reportCollection = database.GetCollection<Report>(databaseSettings.ReportCollectionName);
        }
        public async Task<Report> CreateReportAsync(ReportRequest request)
        {

            var report = new Report
            {
                Location = request.Location,
                HotelCount = 0, 
                PhoneNumberCount = 0, 
                Status = Report.ReportStatus.Pending,
                CreatedDate = DateTime.Now
            };

            await _reportCollection.InsertOneAsync(report);

            return report;
        }

        public async Task<IEnumerable<Report>> GetReportsAsync()
        {
            var reports = await _reportCollection.Find(_ => true).ToListAsync();
            return reports;
        }

        public async Task<Report> GetReportByIdAsync(string id)
        {
            var report = await _reportCollection.Find(r => r.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
            return report;
        }
    }
}
