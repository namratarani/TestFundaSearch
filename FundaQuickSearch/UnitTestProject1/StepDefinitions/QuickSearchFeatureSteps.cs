using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using UnitTestProject1.Pages;

namespace TestFunda.StepDefinitions
{
    [Binding]
    class TestFundaSearchSteps
    {
        private QuickSearchPage searchPage = new QuickSearchPage();
        private SearchResultsPage searchResults;
        private IWebDriver driver = null;
        
        [BeforeScenario()]
         public void Setup()
         {
            driver = new ChromeDriver();
         }

         [AfterScenario()]
         public void TearDown()
         {
            driver.Quit();
         }

        [Given(@"I am at the home page of funda website")]
        public void GivenIAmAtTheHomePageOfFundaWebsite()
        {
            searchPage = QuickSearchPage.NavigateTo(driver);
        }

        [Given(@"quick search component is fully loaded")]
        public void GivenQuickSearchComponentIsFullyLoaded()
        {
           if (searchPage.btnsearch.Displayed == true)
              Console.WriteLine("Quick Search Component is fully loaded");
           else
              Console.WriteLine("Page not loaded fully");
        }

        [When(@"I press zoek")]
        public void WhenIPressZoek()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10000));
            searchResults = searchPage.SubmitSearch();                   
           
        }

        [Then(@"I should be redirected to search reults page")]
        public void ThenIShouldBeRedirectedToSearchReultsPage()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1000));
            string text = driver.Title;
            Console.WriteLine(text);
            Assert.IsTrue(searchResults.IsCurrentPage());
            
        }

        [Then(@"I should see houses from whole netherlands")]
        public void ThenIShouldSeeHousesFromWholeNetherlands()
        {
            String urls = driver.Url;
            String expectedurl = "http://www.funda.nl/koop/heel-nederland/";
            Assert.AreEqual(expectedurl, urls, "User is not redirected to correct search page");
            string result = searchResults.txtinputfieldsearchresult.GetAttribute("value");
            Console.WriteLine(result);
            string text = driver.FindElement(By.XPath(".//div[2]/div[1]/span")).Text;
            Console.WriteLine("Search results from whole netherlands" + text);
        }

        [When(@"I enter (.*) as city in search field")]
        public void WhenIEnterAsCityInSearchField(string city)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1000));
            searchPage.SearchHouseWithInputText(city);
           
        }
       
        [Then(@"I should see houses from '(.*)' in search results page")]
        public void ThenIShouldSeeHousesFromInSearchResultsPage(string city)
        {
            
            String urls = driver.Url;
            String expectedurl = "http://www.funda.nl/koop/"+ city +"/";
            Assert.AreEqual(expectedurl, urls, "User is not redirected to correct search page");
            Console.WriteLine("Current url is " + urls);
            string result = searchResults.txtinputfieldsearchresult.GetAttribute("value");
            Console.WriteLine(result);
            string text = driver.FindElement(By.XPath(".//div[2]/div[1]/span")).Text;
            Console.WriteLine("Search results from amsterdam" + text);
            Console.WriteLine("Search results from whole netherlands" + city);
        }


        [When(@"I enter (.*) as postcode in search field")]
        public void WhenIEnterAsPostcodeInSearchField(int postcode)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1000));
            searchPage.SearchHouseWithPostcode(postcode);
            
        }

        [Then(@"I should be redirected to search reults page of that postcode area")]
        public void ThenIShouldBeRedirectedToSearchReultsPageOfThatPostcodeArea()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1000));
            String urls = driver.Url;
            String expectedurl = "http://www.funda.nl/koop/amstelveen/1187/";
            Assert.AreEqual(expectedurl, urls, "User is not redirected to correct search page");
            Console.WriteLine("Current url is " + urls);
            
        }
        
        [Then(@"I should see houses from (.*) postcode in search results page")]
        public void ThenIShouldSeeHousesFromPostcodeInSearchResultsPage(int postcode)
        {
            string text = driver.FindElement(By.XPath(".//div[2]/div[1]/span")).Text;
            Console.WriteLine("Search results from amsterdam" + text);
            Console.WriteLine("Search results from whole netherlands" + postcode);
        }

        [When(@"I enter '(.*)' as address in search field")]
        public void WhenIEnterAsAddressInSearchField(string address)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1000));
            searchPage.SearchHouseWithInputText(address);
           
        }

        [Then(@"I should be redirected to search reults page of that address")]
        public void ThenIShouldBeRedirectedToSearchReultsPageOfThatAddress()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1000));
            String urls = driver.Url;
            String expectedurl = "http://www.funda.nl/koop/zoetermeer/straat-dunantstraat/";
            Assert.AreEqual(expectedurl, urls, "User is not redirected to correct search page");
            Console.WriteLine("Current url is " + urls);
        }

        [Then(@"I should see houses from '(.*)' address in search results page")]
        public void ThenIShouldSeeHousesFromAddressInSearchResultsPage(string address)
        {
            string text = driver.FindElement(By.XPath(".//div[2]/div[1]/span")).Text;
            Console.WriteLine("Search results from amsterdam" + text);
            Console.WriteLine("Search results from whole netherlands" + address);
        }

        [When(@"I select (.*) as minimum and (.*) as maximum price")]
        public void WhenISelectAsMinimumAndAsMaximumPrice(string minimumpriceddl , string maximumpriceddl)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1000));
            searchPage.SearchHousesWithPriceRange(minimumpriceddl,maximumpriceddl);
        }

        [Then(@"I should see houses in the range of (.*) and (.*) price")]
        public void ThenIShouldSeeHousesInTheRangeOfAndPriceRange(string minimumpriceddl, string maximumpriceddl)
        {
            String urls = driver.Url;
            String expectedurl = "http://www.funda.nl/koop/heel-nederland/50000-100000/";
            Assert.AreEqual(expectedurl, urls, "User is not redirected to correct search page");
            Console.WriteLine("Current url is " + urls);
            string result = searchResults.txtinputfieldsearchresult.GetAttribute("value");
            Console.WriteLine(result);
                        
        }

        [When(@"I select '(.*)' of distance range")]
        public void WhenISelectOfDistanceRange(string distancerange)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1000));
            searchPage.SearchHousesWithDistanceRange(distancerange);
        }

        [Then(@"I should see houses in the range of city'(.*)' within '(.*)' of distance range and '(.*)' to '(.*)' price range")]
        public void ThenIShouldSeeHousesInTheRangeOfCityWithinOfDistanceRangeAndToPriceRange(string city, string distance, string minprice, string maxprice)
        {
            String urls = driver.Url;
            String expectedurl = "http://www.funda.nl/koop/"+city+"/"+distance+"/" + minprice +"-"+ maxprice +"/";
            Assert.AreEqual(expectedurl, urls, "User is not redirected to correct search page");
            Console.WriteLine("Current url is " + urls);
            string result = searchResults.txtinputfieldsearchresult.GetAttribute("value");
            Console.WriteLine(result);
       
        }

       
        [Given(@"I have searched houses for city '(.*)'")]
        public void GivenIHaveSearchedHousesForCity(string Citynew)
        {
            GivenIAmAtTheHomePageOfFundaWebsite();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1000));
            WhenIEnterAsCityInSearchField(Citynew);
            WhenIPressZoek();


        }

        [Given(@"I am on the search results page")]
        public void GivenIAmOnTheSearchResultsPage()
        {
            ThenIShouldBeRedirectedToSearchReultsPage();
        }

        [When(@"I press funda logo on top left corner to go to home page")]
        public void WhenIPressFundaLogoOnTopLeftCornerToGoToHomePage()
        {
            searchResults.imgfundalogo.Click();
           
        }

        [Then(@"I see a link with last search for '(.*)'")]
        public void ThenISeeALinkWithLastSearchFor(string p0)
        {
            if (searchPage.linklastsearched.Displayed == true)
                Console.WriteLine("link exists");
        }

        [When(@"I click the link")]
        public void WhenIClickTheLink()
        {
            searchPage.linklastsearched.Click();
        }

        [Then(@"I am redirected back to search results for '(.*)'")]
        public void ThenIAmRedirectedBackToSearchResultsFor(string p0)
        {
            ThenIShouldBeRedirectedToSearchReultsPage();
        }
        [Given(@"I click '(.*)' tab")]
        public void GivenIClickTab(string tabtext)
        {
            if (tabtext == "huur")
                searchPage.tabhuur.Click();
            else if (tabtext == "nieuwbow")
                searchPage.tabnieuwbouw.Click();
            else if (tabtext == "recreatie")
                searchPage.tabrecreatie.Click();
            else
                searchPage.tabeuropa.Click();

        }

        [Then(@"I should be redirected to search reults page for Huur")]
        public void ThenIShouldBeRedirectedToSearchReultsPageForHuur()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1000));
            string text = driver.Title;
            Console.WriteLine(text);
            Assert.IsTrue(searchResults.IsCurrentPage());

        }
        
        [Then(@"I should see houses for Huur in '(.*)'")]
        public void ThenIShouldSeeHousesForHuurIn(string city)
        {
            String urls = driver.Url;
            String expectedurl = "http://www.funda.nl/huur/" + city+"/";
            Assert.AreEqual(expectedurl, urls, "User is not redirected to correct search page");
            Console.WriteLine("Current url is " + urls);
            string result = searchResults.txtinputfieldsearchresult.GetAttribute("value");
            Console.WriteLine(result);
        }

        [Then(@"I should be redirected to search reults page for Niewbouw")]
        public void ThenIShouldBeRedirectedToSearchReultsPageForNiewbouw()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1000));
            string text = driver.Title;
            Console.WriteLine(text);
            Assert.IsTrue(searchResults.IsCurrentPage());
        }

        [Then(@"I should see Niewbouw projects in '(.*)'")]
        public void ThenIShouldSeeNiewbouwProjectsIn(string city)
        {
            String urls = driver.Url;
            String expectedurl = "http://www.funda.nl/nieuwbouw/" + city+"/";
            Assert.AreEqual(expectedurl, urls, "User is not redirected to correct search page");
            Console.WriteLine("Current url is " + urls);
            string result = searchResults.txtinputfieldsearchresult.GetAttribute("value");
            Console.WriteLine(result);
        }
              

        [Then(@"I am redirected to '(.*)' search page")]
        public void ThenIAmRedirectedToSearchPage(string redirectedurl)
        {
            String urls = driver.Url;
            String expectedurl = "http://www.funda.nl/" + redirectedurl + "/";
            Assert.AreEqual(expectedurl, urls, "User is not redirected to correct search page");
            Console.WriteLine("Current url is " + urls);
        }

        
    }
}
