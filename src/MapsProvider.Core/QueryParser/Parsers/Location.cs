using System;
using System.Text.RegularExpressions;

namespace MapsProvider.Core.QueryParser.Parsers
{
    public class Location : IParameterParser<Location.Parameter>
    {
        private static readonly Regex Regex
            = new Regex(@"where=(?<whereval>.*)", RegexOptions.Compiled);

        public class Parameter : IParameter
        {
            public string Value { get; set; }
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
                Value = Uri.UnescapeDataString(match.Groups["whereval"].Value)
            };
        }
    }
}