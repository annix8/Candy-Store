using System.Windows.Forms;

namespace CandyStore.Client.Messages
{
    public static class NotifyMessageBox
    {
        public static void ShowError(string error)
        {
            if (string.IsNullOrEmpty(error))
            {
                return;
            }

            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccess(string success)
        {
            if (string.IsNullOrEmpty(success))
            {
                return;
            }

            MessageBox.Show(success, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string warning)
        {
            if (string.IsNullOrEmpty(warning))
            {
                return;
            }

            MessageBox.Show(warning, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
