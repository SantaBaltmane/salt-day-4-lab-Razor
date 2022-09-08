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
  public class HeroPageTests
  {
    HeroResponse MOCK_RESPONSE = new HeroResponse
    {
      RequestedAt = DateTime.Now,
      Hero = new Hero { Name = "Captain Kirk" }
    };

    HeroPage pageUnderTest;
    Mock<IHeroAPIClient> _apiServiceMock;
    public HeroPageTests()
    {
      _apiServiceMock = new Mock<IHeroAPIClient>();
      _apiServiceMock.Setup(apiService => apiService.GetHero(It.IsAny<int>()).Result).Returns(MOCK_RESPONSE);

      pageUnderTest = new HeroPage(_apiServiceMock.Object);
    }

    [Fact]
    public void should_create_page()
    {
      // Assert
      pageUnderTest.Should().NotBe(null);
      pageUnderTest.Should().BeOfType<HeroPage>();
    }

    [Fact]
    async public void should_get_hero()
    {
      // Act
      await pageUnderTest.OnGetAsync(123);

      // Assert
      pageUnderTest.HeroResponse.RequestedAt.Should().Be(MOCK_RESPONSE.RequestedAt);
      pageUnderTest.HeroResponse.Hero.Name.Should().Be(MOCK_RESPONSE.Hero.Name);
    }

    [Fact]
    async public void should_handle_exception_from_api()
    {
      // Arrange
      _apiServiceMock = new Mock<IHeroAPIClient>(MockBehavior.Strict);
      _apiServiceMock.Setup(apiService => apiService.GetHero(It.IsAny<int>()).Result).Throws<Exception>();
      pageUnderTest = new HeroPage(_apiServiceMock.Object);

      // Act
      await pageUnderTest.OnGetAsync(123);

      // Assert;
      pageUnderTest.HeroResponse.Should().Be(null);
      pageUnderTest.ErrorMessage.Should().NotBe(String.Empty);
    }
  }
}