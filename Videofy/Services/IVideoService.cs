using Videofy.Models;

namespace Videofy.Services;

public interface IVideoService
{
    List<Video> Get();
    Video Get(string id);
    Video Create(Video video);
    void Update(string id, Video video);
    void Remove(string id);
    
}