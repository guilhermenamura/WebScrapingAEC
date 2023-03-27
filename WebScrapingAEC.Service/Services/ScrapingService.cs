using WebScrapingAEC.Domain.Entities;
using WebScrapingAEC.Domain.Entities.Scraping;
using WebScrapingAEC.Domain.Interfaces;
using WebScrapingAEC.Domain.Interfaces.Scraping;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebScrapingAEC.Service.Services;

public class ScrapingService : IRepository, IScrapingService
{
    public Task<bool> InsertAsync(PublicationSearchResultEntity itens)
    {
        throw new NotImplementedException();
    }

    public bool Get(WordSearchList words)
    {
        bool isError = false;
        int page = 1;
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
                page++;
            }
        }

        return isError;
    }
}