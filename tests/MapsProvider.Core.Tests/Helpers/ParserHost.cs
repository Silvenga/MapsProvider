using MapsProvider.Core.QueryParser;

namespace MapsProvider.Core.Tests.Helpers
{
    public class ParserHost<T, TV> where T : IParameterParser<TV>, new() where TV : IParameter
    {
        public bool CanParse(string queryStringSegment)
        {
            var parser = new T();
            return parser.CanParse(queryStringSegment);
        }

        public TV Parse(string queryStringSegment)
        {
            var parser = new T();
            return parser.Parse(queryStringSegment);
        }
    }
}