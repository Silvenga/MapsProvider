using FluentAssertions;

using MapsProvider.Core.QueryParser.Parsers;
using MapsProvider.Core.Tests.Helpers;

using Xunit;

namespace MapsProvider.Core.Tests.Parsers
{
    public class CenterPointFacts
    {
        private readonly ParserHost<CenterPoint, CenterPoint.Parameter> _host = new ParserHost<CenterPoint, CenterPoint.Parameter>();

        [Fact]
        public void Can_parse_should_be_true()
        {
            const string sample = "cp=40.726966~-74.006076";

            // Act
            var result = _host.CanParse(sample);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Can_parse()
        {
            const string sample = "cp=40.726966~-74.006076";

            // Act
            var result = _host.Parse(sample);

            // Assert
            result.Latitude.Should().Be(40.726966m);
            result.Longitude.Should().Be(-74.006076m);
        }
    }
}