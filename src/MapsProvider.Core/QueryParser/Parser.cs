using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using MapsProvider.Core.QueryParser.Parsers;

namespace MapsProvider.Core.QueryParser
{
    public class Parser
    {
        private static readonly Regex Regex = new Regex(@"bingmaps:\?(?<parm>[^&]+)(&(?<parm>[^&]+))*", RegexOptions.Compiled);

        private static readonly IParameterParser<IParameter>[] ParameterParsers =
        {
            new CenterPoint(),
            new BoundingBox(),
            new Location(),
            new QueryTerm(),
            new ZoomLevel(),
            new Traffic()
        };

        public IList<IParameter> Parse(string queryString)
        {
            var results = from param in ParseQueryGroups(queryString)
                          from parser in ParameterParsers
                          where parser.CanParse(param)
                          select parser.Parse(param);

            return results.ToList();
        }

        private IEnumerable<string> ParseQueryGroups(string queryString)
        {
            var match = Regex.Match(queryString);
            foreach (Capture capture in match.Groups["parm"].Captures)
            {
                yield return capture.Value;
            }
        }
    }
}