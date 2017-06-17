using FluentAssertions;

using MapsProvider.Core.QueryParser;
using MapsProvider.Core.QueryParser.Parsers;

using Xunit;

namespace MapsProvider.Core.Tests
{
    public class ParserFacts
    {
        [Fact]
        public void Can_parse_single_param()
        {
            var parser = new Parser();

            // Act
            var results = parser.Parse("bingmaps:?cp=40.726966~-74.006076");

            // Assert
            results.Should().AllBeOfType<CenterPoint.Parameter>().And.ContainSingle();
        }

        [Fact]
        public void Can_parse_multiple_params()
        {
            var parser = new Parser();

            // Act
            var results = parser.Parse("bingmaps:?cp=40.726966~-74.006076&bb=39.719_-74.52~41.71_-73.5");

            // Assert
            results.Should().HaveCount(2);
        }
    }
}