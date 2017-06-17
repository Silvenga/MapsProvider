using FluentAssertions;

using MapsProvider.Core.QueryParser.Parsers;
using MapsProvider.Core.Tests.Helpers;

using Xunit;

namespace MapsProvider.Core.Tests.Parsers
{
    public class TrafficFacts
    {
        private readonly ParserHost<Traffic, Traffic.Parameter> _host = new ParserHost<Traffic, Traffic.Parameter>();

        [Fact]
        public void Can_parse_should_be_true()
        {
            const string sample = "trfc=1";

            // Act
            var result = _host.CanParse(sample);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Can_parse()
        {
            const string sample = "trfc=1";

            // Act
            var result = _host.Parse(sample);

            // Assert
            result.Value.Should().BeTrue();
        }
    }
}