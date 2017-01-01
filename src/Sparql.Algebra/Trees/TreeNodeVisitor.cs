namespace Sparql.Algebra.Trees
{
    /// <summary>
    /// Tree visitor
    /// </summary>
    /// <typeparam name="TX"></typeparam>
    /// <typeparam name="TY"></typeparam>
    /// <param name="txData"></param>
    /// <returns></returns>
    public delegate TY TreeNodeVisitor<in TX, out TY>(TX txData);
}
