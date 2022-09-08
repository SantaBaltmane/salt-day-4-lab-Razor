using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Salt.Stars.Web.Models;
using Salt.Stars.Web.Pages;
using Salt.Stars.Web.Services;
using Xunit;

namespace Salt.Stars.Web.Tests
{
  public class IndexPageTests
  {

    GreetingResponse MOCK_RESPONSE = new GreetingResponse { Name = "Marcus", Greeting = "Jora" };

    IndexPage pageUnderTest;
    Mock<IGreetingAPIClient> _apiClientMock;
    public IndexPageTests()
    {
      _apiClientMock = new Mock<IGreetingAPIClient>();
      _apiClientMock.Setup(apiClient => apiClient.getGreeting(It.IsAny<string>()).Result).Returns(MOCK_RESPONSE);

      pageUnderTest = new IndexPage(_apiClientMock.Object);
    }

    [Fact]
    public void should_create_page()
    {
      // Assert
      pageUnderTest.Should().NotBe(null);
      pageUnderTest.Should().BeOfType<IndexPage>();
    }

    [Fact]
    public void should_get_action_result()
    {
      // Arrange
      pageUnderTest.DeveloperName = "";

      // Act
      var getResult = pageUnderTest.OnGetAsync();

      // Assert
      getResult.Should().BeOfType<Task<IActionResult>>();
    }

    [Fact]
    async public void should_get_name()
    {
      // Arrange
      pageUnderTest.DeveloperName = "APA";

      // Act
      await pageUnderTest.OnGetAsync();

      // Assert
      _apiClientMock.Verify(p => p.getGreeting("APA"));
      pageUnderTest.Greeting.Name.Should().Be(MOCK_RESPONSE.Name);
    }

    [Fact]
    async public void should_get_greeting()
    {
      // Arrange
      pageUnderTest.DeveloperName = "BANAN";

      // Act
      await pageUnderTest.OnGetAsync();

      // Assert
      _apiClientMock.Verify(p => p.getGreeting("BANAN"));
      pageUnderTest.Greeting.Greeting.Should().Be(MOCK_RESPONSE.Greeting);
    }

    [Fact]
    async public void should_handle_exception_from_API()
    {
      // Arrange
      _apiClientMock = new Mock<IGreetingAPIClient>(MockBehavior.Strict);
      _apiClientMock.Setup(apiClient => apiClient.getGreeting(It.IsAny<string>()).Result).Throws<Exception>();
      pageUnderTest = new IndexPage(_apiClientMock.Object);

      // Arrange
      pageUnderTest.DeveloperName = "BANAN";

      // Act
      await pageUnderTest.OnGetAsync();

      // Assert
      pageUnderTest.Greeting.Should().Be(null);
      pageUnderTest.ErrorMessage.Should().NotBe(string.Empty);
    }
  }
}
