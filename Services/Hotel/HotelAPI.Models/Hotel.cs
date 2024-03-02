using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAPI.Models;

public class Hotel
{
    public Guid UUID { get; set; }

    public string Name { get; set; }

    public List<HotelAuthorized> HotelAuthorizeds { get; set; }

    public List<HotelContact> HotelContacts { get; set; }
}
