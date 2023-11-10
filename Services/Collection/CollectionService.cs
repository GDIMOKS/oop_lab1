using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.Collection.Dtos;
using Services.Song.Dtos;

namespace Services.Collection;

public class CollectionService : ICollectionService
{
    private AudioserviceDbContext _dbContext;

    public CollectionService(AudioserviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<CollectionDto> GetCollections(string name)
    {
        return _dbContext.Collections
            .Where(x => x.Name.ToLower().Contains(name.ToLower()))
            .Select(x => new CollectionDto()
            {
                CollectionId = x.CollectionId,
                Name = x.Name,
                CategoryId = x.CategoryId
            })
            .ToList<CollectionDto>();
    }
    
    public void AddCollection(string name, int categoryId)
    {
        var collection = new Models.Collection() {Name = name, CategoryId = categoryId};
        _dbContext.Collections.Add(collection);
        _dbContext.SaveChanges();
    }

    public void AddSongToCollection(int collectionId, int songId)
    {
        var collection = _dbContext.Collections.FirstOrDefault(c => c.CollectionId == collectionId);
        var song = _dbContext.Songs.Include(song => song.Categories).FirstOrDefault(s => s.SongId == songId);
        
        if (collection != null 
            && song != null 
            && song.Categories.FirstOrDefault(x => x.CategoryId == collection.CategoryId) != null)
        {
            collection.Songs.Add(song);
            _dbContext.SaveChanges();
        }
    }

    public bool DeleteCollection(int id)
    {
        var collection = _dbContext.Collections.FirstOrDefault(x => x.CollectionId == id);
        if (collection != null)
        {
            _dbContext.Collections.Remove(collection);
            _dbContext.SaveChanges();
            return true;
        }

        return false;
    }

    public bool DeleteSongFromCollection(int collectionId, int songId)
    {
       
        var collection = _dbContext.Collections
            .Include(x => x.Songs)
            .FirstOrDefault(x => x.CollectionId == collectionId);
        var song = collection?.Songs.FirstOrDefault(x => x.SongId == songId);
        
        if (song != null)
        {
            collection.Songs.Remove(song);
            _dbContext.SaveChanges();
            return true;
        }

        return false;
    }

    public CollectionDto? GetCollection(int id)
    {
        var collection = _dbContext.Collections.FirstOrDefault(x => x.CollectionId == id);
        return (collection != null)
            ? new CollectionDto()
            {
                CollectionId = collection.CollectionId,
                Name = collection.Name,
                CategoryId = collection.CategoryId
            }
            : null;
    }


    public List<CollectionDto> GetCollections()
    {
        var collections = _dbContext.Collections
            .Select(x => new CollectionDto()
            {
                CollectionId = x.CollectionId,
                Name = x.Name,
                CategoryId = x.CategoryId
            });
        return collections.ToList<CollectionDto>();
    }

    public List<SongDto> GetSongs(int id)
    {
        var collection = _dbContext.Collections
            .Include(x => x.Songs)
            .FirstOrDefault(x => x.CollectionId == id);
        if (collection != null)
        {
            var songs = collection.Songs
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

        return new List<SongDto>();
    }


    public bool UpdateCollection(int id, string name, int categoryId)
    {
        var collection = _dbContext.Collections.FirstOrDefault(x => x.CollectionId == id);
        if (collection != null)
        {
            collection.Name = name;
            collection.CategoryId = categoryId;
            return true;
        }

        return false;
    }
}