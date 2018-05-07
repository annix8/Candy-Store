using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CandyStore.Client.Util
{
    public static class CandyStoreUtil
    {
        public static void MakeLabelsTransparent(Form form)
        {
            foreach (var label in form.Controls.OfType<Label>())
            {
                if (label.Tag?.ToString().ToLower() == "visible")
                {
                    continue;
                }
                label.BackColor = Color.Transparent;
            }
        }
    }
}
