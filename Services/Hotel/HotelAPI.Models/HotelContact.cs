using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAPI.Models;

public class HotelContact
{
    public Guid UUID { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string Location { get; set; }

    public string Content { get; set; }
}
