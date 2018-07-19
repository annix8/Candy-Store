using System;

namespace CandyStore.Contracts.Client.Views
{
    public interface IView
    {
        event EventHandler ViewClosed;
        void Close();
        void Hide();
        void Show();
        void ShowDialog();
    }
}
