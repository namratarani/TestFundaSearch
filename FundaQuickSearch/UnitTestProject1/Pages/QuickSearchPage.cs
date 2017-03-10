using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1.Pages
{
    class QuickSearchPage
    {
 
        [FindsBy(How = How.Id, Using = "autocomplete-input")]
        public IWebElement txtinputfield { get; set; }

        [FindsBy(How = How.Id, Using = "Afstand")]
        public IWebElement ddldistance { get; set; }

        [FindsBy(How = How.Id, Using = "range-filter-selector-select-filter_fundakoopprijsvan")]
        public IWebElement ddlminimumprice { get; set; }

        [FindsBy(How = How.Id, Using = "range-filter-selector-select-filter_fundakoopprijstot")]
        public IWebElement ddlmaximumprice { get; set; }

        [FindsBy(How = How.ClassName, Using = "button-primary-alternative")]
        public IWebElement btnsearch { get; set; }

        [FindsBy(How = How.LinkText, Using = "Huur")]
        public IWebElement tabhuur { get; set; }

        [FindsBy(How = How.LinkText, Using = "Nieuwbouw")]
        public IWebElement tabnieuwbouw { get; set; }

        [FindsBy(How = How.LinkText, Using = "Recreatie")]
        public IWebElement tabrecreatie { get; set; }

        [FindsBy(How = How.LinkText, Using = "Europa")]
        public IWebElement tabeuropa { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[1]/div[4]/form/div[1]/p/a")]
        public IWebElement linklastsearched { get; set; }


        private static IWebDriver driver;

        public static QuickSearchPage NavigateTo(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Navigate().GoToUrl("http://www.funda.nl");
            var searchPage = new QuickSearchPage();
            PageFactory.InitElements(driver, searchPage);
            return searchPage;
        }

        public SearchResultsPage SubmitSearch()
        {
            btnsearch.Click();
            var searchResultsPage = new SearchResultsPage(driver);
            PageFactory.InitElements(driver, searchResultsPage);
            return searchResultsPage;
        }

        public void SearchHouseWithInputText(string inputtext)
         {
            txtinputfield.SendKeys(inputtext);
         }

        public void SearchHouseWithPostcode(int pcode)
        {
            txtinputfield.SendKeys(pcode.ToString());
        }
        public void SearchHouseWithInputTextAndDistance(string inputtext, string distance)
         {
             txtinputfield.SendKeys(inputtext);
             new SelectElement(ddldistance).SelectByText(distance);
             
         }
         
        public void SearchHousesWithPriceRange (string  minimumprice, string  maximumprice)
        {
            //remove the single quote from the price
            string newminprice = minimumprice.Replace("'", string.Empty);
            string newmaxprice = maximumprice.Replace("'", string.Empty);
            new SelectElement(ddlminimumprice).SelectByText(newminprice);
            new SelectElement(ddlmaximumprice).SelectByText(newmaxprice);
            
        }

        public void SearchHousesWithDistanceRange(string distance)
        {
            //remove the single quote from the price
            string newdistance = distance.Replace("'", string.Empty);            
            new SelectElement(ddldistance).SelectByText(newdistance);
            
        }
        
    }
}
