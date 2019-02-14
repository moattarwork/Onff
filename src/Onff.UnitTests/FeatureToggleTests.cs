using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Onff.UnitTests
{
    public class FeatureToggleTests : IClassFixture<FeatureToggleFixture>
    {
        private readonly FeatureToggleFixture _fixture;

        public FeatureToggleTests(FeatureToggleFixture fixture)
        {
            _fixture = fixture;
        }
        
        [Theory]
        [InlineData("Feature1", true)]
        [InlineData("Feature2", false)]
        public void Should_Features_ReturnTheRightStatusFromTheConfiguration(string featureName, bool expected)
        {
            // Arrange
            var sut = _fixture.ServiceProvider.GetRequiredService<IFeatureToggle>();

            // Act
            var actual = sut.IsFeatureEnabled(featureName);

            // Assert
            actual.Should().Be(expected);
        }
    }
}
