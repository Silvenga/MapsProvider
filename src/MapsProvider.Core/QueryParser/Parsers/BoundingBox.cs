using System.Text.RegularExpressions;

namespace MapsProvider.Core.QueryParser.Parsers
{
    public class BoundingBox : IParameterParser<BoundingBox.Parameter>
    {
        private static readonly Regex Regex
            = new Regex(@"bb=(?<southlatitude>-?\d{1,13}(\.\d{1,17})?)_(?<westlongitude>-?\d{1,13}(\.\d{1,17})?)~(?<northlatitude>-?\d{1,12}(\.\d{1,17})?)_(?<eastlongitude>-?\d{1,12}(\.\d{1,17})?)", RegexOptions.Compiled);

        public class Parameter : IParameter
        {
            public decimal SouthLatitude { get; set; }
            public decimal WestLatitude { get; set; }
            public decimal NorthLongitude { get; set; }
            public decimal EastLongitude { get; set; }
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
                SouthLatitude = decimal.Parse(match.Groups["southlatitude"].Value),
                WestLatitude = decimal.Parse(match.Groups["westlongitude"].Value),
                NorthLongitude = decimal.Parse(match.Groups["northlatitude"].Value),
                EastLongitude = decimal.Parse(match.Groups["eastlongitude"].Value),
            };
        }
    }
}