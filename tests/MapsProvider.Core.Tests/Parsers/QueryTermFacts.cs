using FluentAssertions;

using MapsProvider.Core.QueryParser.Parsers;
using MapsProvider.Core.Tests.Helpers;

using Xunit;

namespace MapsProvider.Core.Tests.Parsers
{
    public class QueryTermFacts
    {
        private readonly ParserHost<QueryTerm, QueryTerm.Parameter> _host = new ParserHost<QueryTerm, QueryTerm.Parameter>();

        [Fact]
        public void Can_parse_should_be_true()
        {
            const string sample = "q=mexican%20restaurants";

            // Act
            var result = _host.CanParse(sample);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Can_parse()
        {
            const string sample = "q=mexican%20restaurants";

            // Act
            var result = _host.Parse(sample);

            // Assert
            result.Value.Should().Be("mexican restaurants");
        }
    }
}