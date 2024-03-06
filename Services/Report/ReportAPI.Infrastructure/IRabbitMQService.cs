using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.Infrastructure
{
    public interface IRabbitMQService
    {
        Task SendMessageAsync(string message);
    }
}
