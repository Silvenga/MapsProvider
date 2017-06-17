using FluentAssertions;

using MapsProvider.Core.QueryParser.Parsers;
using MapsProvider.Core.Tests.Helpers;

using Xunit;

namespace MapsProvider.Core.Tests.Parsers
{
    public class LocationFacts
    {
        private readonly ParserHost<Location, Location.Parameter> _host = new ParserHost<Location, Location.Parameter>();

        [Fact]
        public void Can_parse_should_be_true()
        {
            const string sample = "where=1600%20Pennsylvania%20Ave,%20Washington,%20DC";

            // Act
            var result = _host.CanParse(sample);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Can_parse()
        {
            const string sample = "where=1600%20Pennsylvania%20Ave,%20Washington,%20DC";

            // Act
            var result = _host.Parse(sample);

            // Assert
            result.Value.Should().Be("1600 Pennsylvania Ave, Washington, DC");
        }
    }
}