using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;
using Salt.Stars.Web.Models;
using Salt.Stars.Web.Services;
using Salt.Stars.Web.Pages;

namespace Salt.Stars.Web.Tests
{
  public class HeroesPageTests
  {
    HeroListResponse MOCK_RESPONSE = new HeroListResponse
    {
      Count = 143,
      PageSize = 2,
      Heroes = new List<Hero> { new Hero { Name = "Captain Kirk" }, new Hero { Name = "Kosh Naranek" } }
    };

    HeroesPage pageUnderTest;
    Mock<IHeroAPIClient> _apiClientMock;
    public HeroesPageTests()
    {
      _apiClientMock = new Mock<IHeroAPIClient>();
      _apiClientMock.Setup(apiClient => apiClient.GetHeroes().Result).Returns(MOCK_RESPONSE);

      pageUnderTest = new HeroesPage(_apiClientMock.Object);
    }

    [Fact]
    public void should_create_page()
    {
      // Assert
      pageUnderTest.Should().NotBe(null);
      pageUnderTest.Should().BeOfType<HeroesPage>();
    }

    [Fact]
    async public void should_get_heroes()
    {
      // Act
      await pageUnderTest.OnGetAsync();

      // Assert
      _apiClientMock.Verify(p => p.GetHeroes());
      pageUnderTest.HeroesResponse.Count.Should().Be(MOCK_RESPONSE.Count);
      pageUnderTest.HeroesResponse.Heroes.Count.Should().Be(MOCK_RESPONSE.Heroes.Count);
      pageUnderTest.HeroesResponse.Heroes[0].Name.Should().Be(MOCK_RESPONSE.Heroes[0].Name);
    }

    [Fact]
    async public void should_handle_exception_from_api()
    {
      // Arrange
      _apiClientMock = new Mock<IHeroAPIClient>(MockBehavior.Strict);
      _apiClientMock.Setup(apiClient => apiClient.GetHero(It.IsAny<int>()).Result).Throws<Exception>();
      pageUnderTest = new HeroesPage(_apiClientMock.Object);

      // Act
      await pageUnderTest.OnGetAsync();

      // Assert;
      pageUnderTest.HeroesResponse.Should().Be(null);
      pageUnderTest.ErrorMessage.Should().NotBe(String.Empty);
    }
  }
}