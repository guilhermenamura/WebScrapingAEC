using WebScrapingAEC.Domain.Entities;

namespace WebScrapingAEC.Domain.Interfaces;

public interface IRepository
{
    Task<bool> InsertAsync (PublicationSearchResultEntity item);
}