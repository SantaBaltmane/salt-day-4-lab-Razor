using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Salt.Stars.End2End
{
  public class Hero_E2E_Tests : IDisposable
  {
    IWebDriver Driver = null;
    public Hero_E2E_Tests()
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
    public void should_show_hero_page()
    {
      // Act
      Driver.Navigate().GoToUrl($"http://localhost:6001/Hero?id=1");

      // Assert
      IWebElement mainHeader = Driver.FindElement(By.Id("mainHeader"));
      Assert.Contains("Skywalker", mainHeader.Text);
    }
  }
}
