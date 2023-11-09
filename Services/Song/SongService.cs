using DataAccess;
using Services.Category.Dtos;
using Services.Song.Dtos;

namespace Services.Song;

public class SongService : ISongService
{
    private AudioserviceDbContext _dbContext;

    public SongService(AudioserviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddSong(string name, int duration, int authorId, int albumId)
    {
        /*if (albumId == 0)
        {
            var album = new Models.Album() {Name = name, AuthorId = authorId, ReleaseDate = DateTime.Now.Year};
            _dbContext.Add(album);
            albumId = album.AlbumId;
        }*/
        
        var song = new Models.Song() {Name = name, Duration = duration, AuthorId = authorId, AlbumId = albumId};
        _dbContext.Songs.Add(song);
        _dbContext.SaveChanges();
    }

    public bool DeleteSong(int id)
    {
        var song = _dbContext.Songs.FirstOrDefault(x => x.SongId == id);

        if (song != null)
        {
            _dbContext.Songs.Remove(song);
            _dbContext.SaveChanges();
            return true;
        }

        return false;
    }

    public SongDto? GetSong(int id)
    {
        var song = _dbContext.Songs.FirstOrDefault(x => x.SongId == id);
        return (song != null) ? new SongDto()
        {
            SongId = song.SongId, 
            Name = song.Name, 
            Duration = song.Duration, 
            AuthorId = song.AuthorId, 
            AlbumId = song.AlbumId
        } : null;
    }

    public List<SongDto> GetSongs()
    {
        var songs = _dbContext.Songs
            .Select(x => new SongDto()
            {
                SongId = x.SongId, 
                Name = x.Name, 
                AuthorId = x.AuthorId,
                AlbumId = x.AlbumId
            });
        return songs.ToList<SongDto>();
    }

    /*public List<CategoryDto> GetSongCategories(int id)
    {
        
    }*/
    
    public bool UpdateSong(int id, string name, int duration, int authorId, int albumId)
    {
        var song = _dbContext.Songs.FirstOrDefault(x => x.SongId == id);

        if (song != null)
        {
            song.Name = name;
            song.Duration = duration;
            song.AuthorId = authorId;
            song.AlbumId = albumId;

            _dbContext.SaveChanges();
            return true;
        }
        return false;  
    }
}