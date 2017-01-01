namespace Sparql.Algebra.RDF
{
    /// <summary>
    /// Represents the most generic building block of a statement
    /// </summary>
    public interface Term
    {
        /// <summary>
        /// Id
        /// </summary>
        string Id { get; }
    }
}
