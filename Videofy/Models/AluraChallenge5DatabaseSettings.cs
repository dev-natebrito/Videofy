using Videofy.Models.Interfaces;

namespace Videofy.Models;

public class AluraChallenge5DatabaseSettings : IAluraChallenge5DatabaseSettings
{
    public string VideosCollectionName { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}