using FluentAssertions;

using MapsProvider.Core.QueryParser.Parsers;
using MapsProvider.Core.Tests.Helpers;

using Xunit;

namespace MapsProvider.Core.Tests.Parsers
{
    public class BoundingBoxFacts
    {
        private readonly ParserHost<BoundingBox, BoundingBox.Parameter> _host = new ParserHost<BoundingBox, BoundingBox.Parameter>();

        [Fact]
        public void Can_parse_should_be_true()
        {
            const string sample = "bb=39.719_-74.52~41.71_-73.5";

            // Act
            var result = _host.CanParse(sample);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Can_parse()
        {
            const string sample = "bb=39.719_-74.52~41.71_-73.5";

            // Act
            var result = _host.Parse(sample);

            // Assert
            result.SouthLatitude.Should().Be(39.719m);
            result.WestLatitude.Should().Be(-74.52m);
            result.NorthLongitude.Should().Be(41.71m);
            result.EastLongitude.Should().Be(-73.5m);
        }
    }
}