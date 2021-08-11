using FluentAssertions;
using System;
using Xunit;

namespace RocketLander.Tests
{
    public class RocketLandingCheckerTests
    {
        [Theory]
        [InlineData(-1, -5)]
        [InlineData(0, 0)]
        [InlineData(0, 10)]
        [InlineData(10, 0)]
        [InlineData(100, 100)]
        public void Invalid_Platform_Size_Throws_ArgumentOutOfRange_Exception(int x, int y)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new RocketLandingChecker(x, y));
        }

        [Theory]
        [InlineData(16, 15)]
        [InlineData(4, 15)]
        [InlineData(15, 15)]
        [InlineData(15, 5)]
        [InlineData(4, 4)]
        public void Landing_Position_Is_Out_of_Platform(int x, int y)
        {
            var sut = new RocketLandingChecker(10, 10);

            var result = sut.CheckLandingStatus(x, y);

            result.Should().Be(Constants.OutOfPlatformMessage);
        }

        [Fact]
        public void Landing_Position_Is_Ok()
        {
            var sut = new RocketLandingChecker(10, 10);

            var result = sut.CheckLandingStatus(5, 5);

            result.Should().Be(Constants.OkMessage);
        }

        [Fact]
        public void Clash_Landing_With_Position_Previously_Checked()
        {
            var sut = new RocketLandingChecker(10, 10);

            var rocket_1_result = sut.CheckLandingStatus(5, 5);
            var rocket_2_result = sut.CheckLandingStatus(5, 5);

            rocket_1_result.Should().Be(Constants.OkMessage);
            rocket_2_result.Should().Be(Constants.ClashMessage);
        }

        [Theory]
        [InlineData(6, 6)]
        [InlineData(7, 6)]
        [InlineData(8, 6)]
        [InlineData(6, 7)]
        [InlineData(8, 7)]
        [InlineData(6, 8)]
        [InlineData(7, 8)]
        [InlineData(8, 8)]
        public void Clash_Landing_Next_To_Position_Previously_Checked(int x, int y)
        {
            var sut = new RocketLandingChecker(10, 10);

            var rocket_1_result = sut.CheckLandingStatus(7, 7);
            var rocket_2_result = sut.CheckLandingStatus(x, y);

            rocket_1_result.Should().Be(Constants.OkMessage);
            rocket_2_result.Should().Be(Constants.ClashMessage);
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(6, 5)]
        [InlineData(7, 5)]
        [InlineData(8, 5)]
        [InlineData(9, 5)]
        [InlineData(5, 6)]
        [InlineData(9, 6)]
        [InlineData(5, 7)]
        [InlineData(9, 7)]
        [InlineData(5, 8)]
        [InlineData(9, 8)]
        [InlineData(5, 9)]
        [InlineData(6, 9)]
        [InlineData(7, 9)]
        [InlineData(8, 9)]
        [InlineData(9, 9)]
        public void Ok_Landing_Away_From_Previously_Checked_Position_By_One_Unit(int x, int y)
        {
            var sut = new RocketLandingChecker(10, 10);

            var rocket_1_result = sut.CheckLandingStatus(7, 7);
            var rocket_2_result = sut.CheckLandingStatus(x, y);

            rocket_1_result.Should().Be(Constants.OkMessage);
            rocket_2_result.Should().Be(Constants.OkMessage);
        }
    }
}
