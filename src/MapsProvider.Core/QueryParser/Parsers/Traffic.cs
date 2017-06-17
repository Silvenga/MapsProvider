using System.Text.RegularExpressions;

namespace MapsProvider.Core.QueryParser.Parsers
{
    public class Traffic : IParameterParser<Traffic.Parameter>
    {
        private static readonly Regex Regex
            = new Regex(@"trfc=(?<trfc>[01])", RegexOptions.Compiled);

        public class Parameter : IParameter
        {
            public bool Value { get; set; }
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
                Value = match.Groups["trfc"].Value == "1"
            };
        }
    }
}