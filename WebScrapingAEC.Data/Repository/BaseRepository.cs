using WebScrapingAEC.Data.Context;
using WebScrapingAEC.Domain.Entities;
using WebScrapingAEC.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebScrapingAEC.Data.Repository;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity{
    
    protected readonly MyContext _context;
    private DbSet<PublicationSearchResultEntity> _dataset;
    public BaseRepository(MyContext context)
    {
        _context = context;
        _dataset = _context.Set<PublicationSearchResultEntity>();
    }
    
    public async Task<bool> InsertAsync(PublicationSearchResultEntity item)
    {
        try
        {
            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }

            item.RunWebScrapingAt = DateTime.UtcNow;
            _dataset.Add(item);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }
}