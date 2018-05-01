using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandyStore.Client.Prompt
{
    public static class PromptMessage
    {
        public static bool ConfirmationMessage(string message)
        {
            var title = "Confirm!";
            var result = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    return true;
                default:
                    return false;
            }

        }
    }
}
