using DataAccess;
using Services.Album.Dtos;

namespace Services.Album;

public class AlbumService : IAlbumService
{
    private AudioserviceDbContext _dbContext;
    
    public AlbumService(AudioserviceDbContext dbContext)
    {
        _dbContext = dbContext;
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