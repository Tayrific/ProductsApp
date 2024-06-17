using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace ProductsApp.Test
{
    [Binding]
    public class FeatureProductsAppStepDefinitions
    {
        private IWebDriver _driver;
        private String _newItem;

        [Given(@"I am on the create item screen")]
        public void GivenIAmOnTheCreateItemScreen()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("https://localhost:44371/Product/Create");


        }

        [Given(@"I enter a name of (.*)")]
        public void GivenIEnterANameOf(String itemName)
        {
            _newItem = itemName;

            _driver.FindElement(By.Id("ProductName")).SendKeys(itemName);
        }

        [Given(@"I enter a price of (.*)")]
        public void GivenIEnterAPriceOf(int p0)
        {
            _driver.FindElement(By.Id("Price")).SendKeys("7");
        }

        [Given(@"I enter a Description of (.*)")]
        public void GivenIEnterADescriptionOf(string itemDescription)
        {
            _driver.FindElement(By.Id("Description")).SendKeys(itemDescription);
        }

        [When(@"I submit my new item by clicking create")]
        public void WhenISubmitMyNewItemByClickingCreate()
        {
            _driver.FindElement(By.Id("Submit")).Click();
        }

        [Then(@"I should see the Item get added to the list\.")]
        public void ThenIShouldSeeTheItemGetAddedToTheList_()
        {
            _driver.Navigate().GoToUrl("https://localhost:44371/Product");
            var table = _driver.FindElement(By.CssSelector("table"));
            var rows = table.FindElements(By.TagName("tr"));

            bool itemFound = false;

            foreach (var row in rows)
            {
                var cells = row.FindElements(By.TagName("td"));
                foreach (var cell in cells)
                {
                    if (cell.Text.Contains(_newItem))
                    {
                        itemFound = true;
                        break;
                    }
                }
                if (itemFound)
                {
                    break;
                }
            }

            Assert.True(itemFound, $"The item '{_newItem}' was not found in the table.");
        }

        [Then(@"I should see an error message telling me price is required\.")]
        public void ThenIShouldSeeAnErrorMessageTellingMePriceIsRequired_()
        {
            IWebElement errorElement = _driver.FindElement(By.Id("Price-error"));

            Assert.Equal("price required", errorElement.Text);
        }


        [AfterScenario]
        public void disposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}
