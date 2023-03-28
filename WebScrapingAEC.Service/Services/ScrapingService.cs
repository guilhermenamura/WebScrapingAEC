using System.Text.RegularExpressions;
using WebScrapingAEC.Domain.Entities;
using WebScrapingAEC.Domain.Entities.Scraping;
using WebScrapingAEC.Domain.Interfaces;
using WebScrapingAEC.Domain.Interfaces.Scraping;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebScrapingAEC.Data.Repository;

namespace WebScrapingAEC.Service.Services;

public class ScrapingService : IScrapingService
{
    
    public bool Get(WordSearchList words)
    {
        bool isError = false;
        int page = 1;
        IEnumerable<PublicationSearchResultEntity> virtualMatrixPublicationSearchResult = new List<PublicationSearchResultEntity>();
        string patternTitle = @"(?<=<h3 class=""tres-linhas"">).*?(?=<\/h3>)";
        string patternArea = @"<span\s+class=""hat"">([^<]*)<\/span>";
        string patternDescricao = @"<p class=""duas-linhas"">(.+?)<\/p>";
        string patternPublicadoPor = @"(?<=<span><small>Publicado por ).*?(?= em \d{2}/\d{2}/\d{4})";        
        string patternData = @"(?<=<span><small>Publicado por .+ em )\d{2}\/\d{2}\/\d{4}";
        
        using (IWebDriver driver = new FirefoxDriver())
        {
            while (true)
            {
                var url = $"https://www.aec.com.br/page/{page}/?s={words.WordList[0].Word}";
                driver.Navigate().GoToUrl(url);
                isError = driver.PageSource.Contains("Erro 404.");
                if (isError)
                {
                    IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                    jsExecutor.ExecuteScript($"console.log('{"Erro"}');");                    
                    Thread.Sleep(10000); 
                    break;
                }
                else
                {
                    string html = driver.PageSource;
                    string searchTerm = "Resultados encontrados para o termo:";
                    int startIndex = html.IndexOf(searchTerm) + searchTerm.Length;
                    string resultados = html.Substring(startIndex);
                    searchTerm = "<div class=\"container\">";
                    startIndex = resultados.IndexOf(searchTerm) + searchTerm.Length;
                    resultados = resultados.Substring(startIndex);

                    int lastNewLineIndex = resultados.LastIndexOf("\n", resultados.Length - 1); 
                    for (int i = 0; i < 288; i++) // remove as últimas 288 linhas
                    {
                        lastNewLineIndex = resultados.LastIndexOf("\n", lastNewLineIndex - 1);
                    }
                    resultados = resultados.Substring(0, lastNewLineIndex + 1);
                    string[] substrings = resultados.Split(new string[] { "<a href=" }, StringSplitOptions.None).Skip(1).ToArray();
                    
                    foreach (var item in substrings)
                    {
                        Match titulo = Regex.Match(item, patternTitle);
                        Match area = Regex.Match(item, patternArea);
                        Match descricao = Regex.Match(item, patternDescricao);
                        Match publicadoPor = Regex.Match(item, patternPublicadoPor);
                        Match data = Regex.Match(item, patternData);
                        
                        var newPublication = new PublicationSearchResultEntity()
                        {
                            Titulo = titulo.Value,
                            Area = area.Groups[1].Value,
                            Autor = publicadoPor.Value,
                            Descricao = descricao.Groups[1].Value,
                            DataPublicacao = data.Value
                        };
                        virtualMatrixPublicationSearchResult = virtualMatrixPublicationSearchResult.Concat(new[] { newPublication });
                    }
                }
                page++;
            }
        }
        
        foreach (var item in virtualMatrixPublicationSearchResult)
        {
            //InsertAsync(item);
        }

        return isError;
    }
}