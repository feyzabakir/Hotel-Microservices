using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAPI.Models;

public class HotelContact : BaseEntity
{
    public string Phone { get; set; }

    public string Email { get; set; }

    public string Location { get; set; }

    public string Content { get; set; }

    [BsonElement("HotelId")]
    public ObjectId HotelId { get; set; }
}
