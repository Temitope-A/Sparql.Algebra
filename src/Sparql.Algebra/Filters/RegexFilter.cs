namespace Sparql.Algebra.Filters
{
    /// <summary>
    /// A simple regex filter
    /// </summary>
    public class RegexFilter:IFilter
    {
        private string _regex;
        private string _valueName;

        /// <summary>
        /// Constructor
        /// </summary>
        public RegexFilter(string valueName, string regex)
        {
            _valueName = valueName;
            _regex = regex;
        }

        /// <summary>
        /// Render the filter to string
        /// </summary>
        public override string ToString()
        {
            return $"regex({_valueName}, \"{_regex}\")";
        }
    }
}
