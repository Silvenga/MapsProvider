using System.Text.RegularExpressions;

namespace MapsProvider.Core.QueryParser.Parsers
{
    public class CenterPoint : IParameterParser<CenterPoint.Parameter>
    {
        private static readonly Regex Regex
            = new Regex(@"cp=(?<degreeslat>-?\d{1,13}(\.\d{1,17})?)~(?<degreeslon>-?\d{1,12}(\.\d{1,17})?)", RegexOptions.Compiled);

        public class Parameter : IParameter
        {
            public decimal Latitude { get; set; }

            public decimal Longitude { get; set; }
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
                Latitude = decimal.Parse(match.Groups["degreeslat"].Value),
                Longitude = decimal.Parse(match.Groups["degreeslon"].Value)
            };
        }
    }
}