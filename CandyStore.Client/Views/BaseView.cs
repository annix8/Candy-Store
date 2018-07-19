using CandyStore.Contracts.Client.Views;
using System;
using System.Windows.Forms;

namespace CandyStore.Client.Views
{
    public class BaseView : Form, IView
    {
        public event EventHandler ViewClosed;

        void IView.ShowDialog()
        {
            ShowDialog();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ViewClosed?.Invoke(this, e);
            base.OnFormClosed(e);
        }
    }
}
