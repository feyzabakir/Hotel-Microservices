using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAPI.Models;

public class HotelAuthorized
{
    public Guid UUID { get; set; }

    public string AuthorizedName { get; set; }

    public string AuthorizedSurname { get; set; }

    public string Title { get; set; }
}
