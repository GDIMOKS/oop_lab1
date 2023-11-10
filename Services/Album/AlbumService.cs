using DataAccess;
using Services.Album.Dtos;
using Services.Song.Dtos;

namespace Services.Album;

public class AlbumService : IAlbumService
{
    private AudioserviceDbContext _dbContext;
    
    public AlbumService(AudioserviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<AlbumDto> GetAlbums(string name)
    {
       return _dbContext.Albums
           .Where(x => x.Name.ToLower().Contains(name.ToLower()))
           .Select(x => new AlbumDto()
           {
               AlbumId = x.AlbumId, 
               Name = x.Name, 
               AuthorId = x.AuthorId,
               ReleaseDate = x.ReleaseDate
           })
           .ToList<AlbumDto>();
    }
    public void AddAlbum(string name, int authorId, int releaseDate)
    {
        var album = new Models.Album() {Name = name, AuthorId = authorId, ReleaseDate = releaseDate};
        _dbContext.Albums.Add(album);
        _dbContext.SaveChanges();
    }

    public bool DeleteAlbum(int id)
    {
        var album = _dbContext.Albums.FirstOrDefault(x => x.AlbumId == id);

        if (album != null)
        {
            _dbContext.Albums.Remove(album);
            _dbContext.SaveChanges();
            return true;
        }

        return false;
    }

    public AlbumDto? GetAlbum(int id)
    {
        var album = _dbContext.Albums.FirstOrDefault(x => x.AlbumId == id);
        return (album != null) ? new AlbumDto()
        {
            AlbumId = album.AlbumId, 
            Name = album.Name, 
            ReleaseDate = album.ReleaseDate
        } : null;
    }

    public List<AlbumDto> GetAlbums()
    {
        var albums = _dbContext.Albums
            .Select(x => new AlbumDto()
            {
                AlbumId = x.AlbumId, 
                Name = x.Name, 
                AuthorId = x.AuthorId,
                ReleaseDate = x.ReleaseDate
            });
        return albums.ToList<AlbumDto>();
    }

    public List<SongDto> GetSongs(int id)
    {
        var songs = _dbContext.Songs
            .Where(x => x.AlbumId == id)
            .Select(x => new SongDto()
            {
                SongId = x.SongId,
                Name = x.Name,
                AlbumId = x.AlbumId,
                AuthorId = x.AuthorId,
                Duration = x.Duration
            });
        return songs.ToList<SongDto>();
    }

    public bool UpdateAlbum(int id, string name, int authorId, int releaseDate)
    {
        var album = _dbContext.Albums.FirstOrDefault(x => x.AlbumId == id);

        if (album != null)
        {
            album.AlbumId = id;
            album.Name = name;
            album.AuthorId = authorId;
            album.ReleaseDate = releaseDate;

            _dbContext.SaveChanges();
            return true;
        }
        return false; 
    }
}