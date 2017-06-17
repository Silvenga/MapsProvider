using FluentAssertions;

using MapsProvider.Core.QueryParser.Parsers;
using MapsProvider.Core.Tests.Helpers;

using Xunit;

namespace MapsProvider.Core.Tests.Parsers
{
    public class ZoomLevelFacts
    {
        private readonly ParserHost<ZoomLevel, ZoomLevel.Parameter> _host = new ParserHost<ZoomLevel, ZoomLevel.Parameter>();

        [Fact]
        public void Can_parse_should_be_true()
        {
            const string sample = "lvl=10.50";

            // Act
            var result = _host.CanParse(sample);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Can_parse()
        {
            const string sample = "lvl=10.50";

            // Act
            var result = _host.Parse(sample);

            // Assert
            result.Value.Should().Be(10.50m);
        }
    }
}