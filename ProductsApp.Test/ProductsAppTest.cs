using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace ProductsApp.Test
{
    public class ProductsAppTest
    {

        [Fact]
        public void startApp()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://localhost:44371/");

                IWebElement applicationButton = driver.FindElement(By.Id("createNewLink"));
                applicationButton.Click();

                Thread.Sleep(3000);

                Assert.Equal("Create - Products App", driver.Title);
            }
        }

        [Fact]
        public void CreateNew()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://localhost:44371/Product/Create");

                driver.FindElement(By.Id("ProductName")).SendKeys("Test Mango");
                driver.FindElement(By.Id("Price")).SendKeys("7");
                driver.FindElement(By.Id("Description")).SendKeys("Test Description");

                driver.FindElement(By.Id("Submit")).Click();

            }
        }

        [Fact]
        public void Delete()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://localhost:44371/Product");
                           

            }
        }
    }
}
