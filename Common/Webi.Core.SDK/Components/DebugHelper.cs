using System.Diagnostics;
using System.Text;

namespace Webi.Core.SDK.Components
{
    public class DebugHelper
    {
        public void PrintOutput(string message)
        {
            var sbDebug = new StringBuilder();
            var sbFix = new StringBuilder("DEBUG: ");
            for (int i = 0; i < 100; i++)
            {
                sbFix.Append("=");
            }
            sbFix.Append(">>");
            sbDebug.AppendLine();
            sbDebug.AppendLine(sbFix.ToString());
            sbDebug.Append("Print: ");
            sbDebug.AppendLine(message);
            sbDebug.AppendLine(sbFix.ToString());
            Debug.WriteLine(sbDebug.ToString());
        }
    }
}