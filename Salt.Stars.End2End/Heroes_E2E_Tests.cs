using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Salt.Stars.End2End
{
  public class Heroes_E2E_Tests : IDisposable
  {
    IWebDriver Driver = null;
    public Heroes_E2E_Tests()
    {
      Driver = new ChromeDriver();
    }

    public void Dispose()
    {
      if (Driver != null)
      {
        Driver.Quit();
        Driver = null;
      }
    }

    [Fact]
    public void should_show_heroes_page()
    {
      // Act
      Driver.Navigate().GoToUrl($"http://localhost:6001/heroes");

      // Assert
      IWebElement mainHeader = Driver.FindElement(By.Id("mainHeader"));
      Assert.Contains("The Heroes list", mainHeader.Text);

      int rowCount = Driver.FindElements(By.XPath("//*[@id='heroesTable']/tbody/tr")).Count;
      Assert.Equal(10, rowCount);
    }
  }
}
