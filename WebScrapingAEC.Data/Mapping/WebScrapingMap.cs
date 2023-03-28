using WebScrapingAEC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebScrapingAEC.Data.Mapping;

public class WebScrapingMap : IEntityTypeConfiguration<PublicationSearchResultEntity>
{
    public void Configure(EntityTypeBuilder<PublicationSearchResultEntity> builder)
    {
        builder.ToTable("WebScraping");
        
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Titulo);
        builder.HasIndex(p => p.Area);
        builder.HasIndex(p => p.Autor);
        builder.HasIndex(p => p.Descricao);
        builder.HasIndex(p => p.DataPublicacao);
    }

}