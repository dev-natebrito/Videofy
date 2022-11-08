namespace Videofy.Models.Interfaces;

public interface IAluraChallenge5DatabaseSettings
{
    string VideosCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}