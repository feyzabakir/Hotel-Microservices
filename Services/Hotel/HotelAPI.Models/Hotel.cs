using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAPI.Models;

public class Hotel : BaseEntity
{
    public string Name { get; set; }

    public ICollection<HotelAuthorized> HotelAuthorizeds { get; set; }

    public ICollection<HotelContact> HotelContacts { get; set; }
}
