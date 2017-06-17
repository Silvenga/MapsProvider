using System;
using System.Text.RegularExpressions;

namespace MapsProvider.Core.QueryParser.Parsers
{
    public class ZoomLevel : IParameterParser<ZoomLevel.Parameter>
    {
        private static readonly Regex Regex
            = new Regex(@"lvl=(?<lvl>\d{1,12}(\.\d{1,12}))", RegexOptions.Compiled);

        public class Parameter : IParameter
        {
            public decimal Value { get; set; }
        }

        public bool CanParse(string queryStringSegment)
        {
            return Regex.IsMatch(queryStringSegment);
        }

        public Parameter Parse(string queryStringSegment)
        {
            var match = Regex.Match(queryStringSegment);
            return new Parameter
            {
                Value = decimal.Parse(match.Groups["lvl"].Value)
            };
        }
    }
}