using MongoDB.Driver;
using Videofy.Models;
using Videofy.Models.Interfaces;

namespace Videofy.Services;

public class VideoService : IVideoService
{
    private readonly IMongoCollection<Video> _videos;

    public VideoService(IAluraChallenge5DatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _videos = database.GetCollection<Video>(settings.VideosCollectionName);
    }
 
    public List<Video> Get()
    {
        return _videos.Find(video => true).ToList();
    }

    public Video Get(string id)
    {
        return _videos.Find(v => v.Id == id).FirstOrDefault();
    }

    public Video Create(Video video)
    {
        _videos.InsertOne(video);
        return video;
    }

    public void Update(string id, Video video)
    {
        _videos.ReplaceOne(v => v.Id == id, video);
    }

    public void Remove(string id)
    {
        _videos.DeleteOne(v => v.Id == id);
    }
}