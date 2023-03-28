using System.ComponentModel.DataAnnotations;
namespace WebScrapingAEC.Domain.Entities;

public abstract class BaseEntity {
    
    [Key]
    public Guid Id { get; set; }

    private readonly DateTime _runWebScrapingAt = DateTime.UtcNow;
    public DateTime RunWebScrapingAt
    {
        get => _runWebScrapingAt;
        set => throw new NotImplementedException();
    }
}