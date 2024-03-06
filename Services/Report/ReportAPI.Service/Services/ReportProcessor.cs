using ReportAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.Service.Services
{
    public class ReportProcessor : IReportProcessor
    {
        public async Task ProcessReportRequestAsync(string message)
        {
            Console.WriteLine("Rapor talebi işleniyor: " + message);

            Console.WriteLine("Gelen mesaj: " + message);
        }
    }
}
