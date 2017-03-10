using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace UnitTestProject1.Pages
{
    class SearchResultsPage
    {

        private static IWebDriver driver;
        
        public SearchResultsPage(IWebDriver webDriver)
        {
            driver = webDriver;
            
        }

        [FindsBy(How = How.Id, Using = "autocomplete-input")]
        public IWebElement txtinputfieldsearchresult { get; set; }

        [FindsBy(How = How.Id, Using = "Afstand")]
        public IWebElement ddldistancesearchresult { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".search-header-submit.button-primary")]
        public IWebElement btnsearchpageresult { get; set; }

        [FindsBy(How = How.XPath, Using = "//div/nav/a/img")]
        public IWebElement imgfundalogo { get; set; }


        public bool IsCurrentPage()
        {
            string titletext = driver.Title;
            if (driver.Title.Contains("Huizen te koop in"))
                return true;
            else if (driver.Title.Contains("Huizen te huur in"))
                return true;
            else if (driver.Title.Contains("Nieuwbouwprojecten in"))
                return true;
            else if (driver.Title.Contains("Zoek recreatiewoningen in Nederland [funda]"))
                return true;
            else if (driver.Title.Contains("Zoek huizen en appartementen in Europa [funda]"))
                return true;
            else
                return false;

        }

    }
}
