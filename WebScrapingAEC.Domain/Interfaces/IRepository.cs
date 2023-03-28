using WebScrapingAEC.Domain.Entities;

namespace WebScrapingAEC.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity {
    Task<bool> InsertAsync (PublicationSearchResultEntity item);
}