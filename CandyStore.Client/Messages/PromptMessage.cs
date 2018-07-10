using System.Windows.Forms;

namespace CandyStore.Client.Messages
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
