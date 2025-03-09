using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nthAPIWeb.models;

public class Player
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] // Mongo lo manejará como ObjectId
    public string? _id { get; set; }
    public int lastCheckPoint { get; set; }
    public int deaths { get; set; }
}