namespace Sparql.Algebra.Rows
{
    public class SignatureRow : IMultiSetRow
    {
        public string[] VariableList { get; set; }
        public SignatureRow(string[] data)
        {
            VariableList = data;
        }
    }
}
