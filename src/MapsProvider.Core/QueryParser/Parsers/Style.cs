using System;

namespace MapsProvider.Core.QueryParser.Parsers
{
    public class Style : IParameterParser<Style.Parameter>
    {
        public class Parameter : IParameter
        {
            public StyleMode Value { get; set; }
        }

        public enum StyleMode
        {
            A,
            R,
            ThreeDimensional
        }

        public bool CanParse(string queryStringSegment)
        {
            return false;
        }

        public Parameter Parse(string queryStringSegment)
        {
            throw new NotImplementedException();
        }
    }
}