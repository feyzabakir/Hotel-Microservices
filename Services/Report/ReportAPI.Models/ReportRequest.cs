using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.Models
{
    public class ReportRequest
    {
        public ObjectId ReportId { get; set; }
        public string Location { get; set; }
    }
}
