using Services.Song.Dtos;

namespace Services.Song;

public interface ISongService
{
    void AddSong(string name, int duration, int authorId, int albumId);
    bool DeleteSong(int id);
    SongDto? GetSong(int id);
    List<SongDto> GetSongs();
    bool UpdateSong(int id, string name, int duration, int authorId, int albumId);
}