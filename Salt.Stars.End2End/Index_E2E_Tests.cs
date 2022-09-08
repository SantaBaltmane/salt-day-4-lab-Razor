using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Salt.Stars.End2End
{
  public class Index_E2E_Tests : IDisposable
  {
    IWebDriver Driver = null;
    public Index_E2E_Tests()
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
    public void Index_Page_Shows_without_name()
    {
      // Act
      Driver.Navigate().GoToUrl($"http://localhost:6001/");

      // Assert
      IWebElement mainHeader = Driver.FindElement(By.Id("mainHeader"));
      Assert.Contains("Get your greeting below", mainHeader.Text);
    }

    [Fact]
    public void Index_Page_Shows_for_name()
    {
      // Arrange
      var testName = "Marcus";

      // Act
      Driver.Navigate().GoToUrl($"http://localhost:6001/?DeveloperName={testName}");

      // Assert
      IWebElement mainHeader = Driver.FindElement(By.Id("greeting"));
      Assert.Contains(testName, mainHeader.Text);
    }
  }
}
