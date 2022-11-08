using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Videofy.Models;

public class Video
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = String.Empty;

    [BsonElement("titulo")] public string Titulo { get; set; } = null!;

    [BsonElement("descricao")] public string Descricao { get; set; } = null!;

    [BsonElement("url")] public string Url { get; set; } = null!;
}