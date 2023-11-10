using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.Category.Dtos;
using Services.Collection.Dtos;
using Services.Song.Dtos;

namespace Services.Song;

public class SongService : ISongService
{
    private AudioserviceDbContext _dbContext;

    public SongService(AudioserviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<SongDto> GetSongs(string name)
    {
        return _dbContext.Songs
            .Where(x => x.Name.ToLower().Contains(name.ToLower()))
            .Select(x => new SongDto()
            {
                SongId = x.SongId, 
                Name = x.Name, 
                Duration = x.Duration,
                AuthorId = x.AuthorId,
                AlbumId = x.AlbumId
            })
            .ToList<SongDto>();
    }
    

    public void AddSong(string name, int duration, int authorId, int albumId)
    {
        var album = _dbContext.Albums.FirstOrDefault(x => x.AlbumId == albumId);
        if (album == null) return;
        if (album.AuthorId != authorId) return;
        
        var song = new Models.Song() {Name = name, Duration = duration, AuthorId = authorId, AlbumId = albumId};
        _dbContext.Songs.Add(song);
        _dbContext.SaveChanges();

    }

    public void AddCategoryToSong(int songId, int categoryId)
    {
        var song = _dbContext.Songs.FirstOrDefault(s => s.SongId == songId);
        var category = _dbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        
        if (song != null && category != null)
        {
            song.Categories.Add(category);
            _dbContext.SaveChanges();
        }
    }
    
    public void AddCollectionToSong(int songId, int collectionId)
    {
        var song = _dbContext.Songs.Include(song => song.Categories).FirstOrDefault(s => s.SongId == songId);
        var collection = _dbContext.Collections.FirstOrDefault(c => c.CollectionId == collectionId);
        
        if (song != null 
            && collection != null 
            && song.Categories.FirstOrDefault(x => x.CategoryId == collection.CategoryId) != null
            )
        {
            song.Collections.Add(collection);
            _dbContext.SaveChanges();
        }
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

    public bool DeleteCategoryFromSong(int songId, int categoryId)
    {
        var song = _dbContext.Songs.Include(x => x.Categories).FirstOrDefault(x => x.SongId == songId);

        var category = song?.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
        if (category != null)
        {
            song.Categories.Remove(category);
            _dbContext.SaveChanges();
            return true;
        }

        return false;
    }

    public bool DeleteCollectionFromSong(int songId, int collectionId)
    {
        var song = _dbContext.Songs.Include(x => x.Collections).FirstOrDefault(x => x.SongId == songId);

        var collection = song?.Collections.FirstOrDefault(x => x.CollectionId == collectionId);
        
        if (collection != null)
        {
            song.Collections.Remove(collection);
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
                Duration = x.Duration,
                AuthorId = x.AuthorId,
                AlbumId = x.AlbumId
            });
        return songs.ToList<SongDto>();
    }

    public List<CategoryDto> GetSongCategories(int id)
    {
        var song = _dbContext.Songs
            .Include(song => song.Categories)
            .FirstOrDefault(x => x.SongId == id);
        if (song != null)
        {
            var categories = song.Categories
                .Select(x => new CategoryDto()
            {
                CategoryId = x.CategoryId,
                Name = x.Name,
                ParentCategoryId = x.ParentCategoryId
            });

            return categories.ToList<CategoryDto>();

        }

        return new List<CategoryDto>();
    }
    
    public List<CollectionDto> GetSongCollections(int id)
    {
        var song = _dbContext.Songs
            .Include(song => song.Collections)
            .FirstOrDefault(x => x.SongId == id);
        if (song != null)
        {
            var collections = song.Collections
                .Select(x => new CollectionDto()
            {
                CollectionId = x.CollectionId,
                Name = x.Name,
                CategoryId = x.CategoryId
            });

            return collections.ToList<CollectionDto>();

        }

        return new List<CollectionDto>();
    }
    
    public bool UpdateSong(int id, string name, int duration, int authorId, int albumId)
    {
        var album = _dbContext.Albums.FirstOrDefault(x => x.AlbumId == albumId);
        
        if (album == null) return false;
        if (album.AuthorId != authorId) return false;
        
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