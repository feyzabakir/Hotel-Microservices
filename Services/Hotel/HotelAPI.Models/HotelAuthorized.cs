using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAPI.Models;

public class HotelAuthorized : BaseEntity
{

    public string AuthorizedName { get; set; }

    public string AuthorizedSurname { get; set; }

    public string Title { get; set; }

    [BsonElement("HotelId")]
    public ObjectId HotelId { get; set; }
}
