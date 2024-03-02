using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAPI.Service.Settings;

public interface IDatabaseSettings
{
    public string HotelCollectionName { get; set; }
    public string HotelAuthorizedCollectionName { get; set; }
    public string HotelContactCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}
