using CandyStore.Contracts.Client.Facades;
using System.Text;

namespace CandyStore.Client.Facades
{
    public class StringBuilderFacade : IStringBuilderFacade
    {
        private readonly StringBuilder _sb;

        public StringBuilderFacade()
        {
            _sb = new StringBuilder();
        }

        public void AppendLine(string text)
        {
            _sb.AppendLine(text);
        }

        public override string ToString()
        {
            var resultString = _sb.ToString();
            _sb.Clear();
            return resultString;
        }
    }
}
