using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.Models
{
    public class Report : BaseEntity
    {
        public string Location { get; set; }
        public int HotelCount { get; set; }
        public int PhoneNumberCount { get; set; }
        public ReportStatus Status { get; set; }

        public enum ReportStatus
        {
            Pending,
            Completed
        }
    }
}
