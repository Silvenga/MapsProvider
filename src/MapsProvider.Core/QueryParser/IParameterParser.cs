namespace MapsProvider.Core.QueryParser
{
    public interface IParameterParser<out T> where T : IParameter
    {
        bool CanParse(string queryStringSegment);

        T Parse(string queryStringSegment);
    }

    public interface IParameter
    {
    }
}