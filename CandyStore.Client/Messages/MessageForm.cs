using System.Windows.Forms;

namespace CandyStore.Client.Messages
{
    public static class MessageForm
    {
        public static void ShowError(string error)
        {
            MessageBox.Show(error,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        public static void ShowSuccess(string success)
        {
            MessageBox.Show(success, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string warning)
        {
            MessageBox.Show(warning,"Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
    }
}
