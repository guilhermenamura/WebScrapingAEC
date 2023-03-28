using System.ComponentModel.DataAnnotations;
namespace WebScrapingAEC.Domain.Entities;

public abstract class BaseEntity {
    private readonly DateTime _runWebScrapingAt = DateTime.UtcNow;
    public DateTime RunWebScrapingAt => _runWebScrapingAt;
}