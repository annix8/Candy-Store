using CandyStore.Contracts.Client.Views;
using System.Windows.Forms;

namespace CandyStore.Contracts.Client.Services
{
    public interface IViewService
    {
        void ShowView<TView>(Form currentForm) where TView : class, IView;
    }
}
