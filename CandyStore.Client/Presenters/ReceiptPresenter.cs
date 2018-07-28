using CandyStore.Client.Cache;
using CandyStore.Contracts.Client.Facades;
using CandyStore.Contracts.Client.Presenters;
using CandyStore.Contracts.Client.Views;
using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.Models;
using System.Linq;

namespace CandyStore.Client.Presenters
{
    public class ReceiptPresenter : IReceiptPresenter
    {
        private readonly ICandyStoreRepository _candyStoreRepository;
        private readonly IStringBuilderFacade _stringBuilderFacade;
        private readonly IDateTimeFacade _dateTimeFacade;

        public ReceiptPresenter(ICandyStoreRepository candyStoreRepository,
            IStringBuilderFacade stringBuilderFacade,
            IDateTimeFacade dateTimeFacade)
        {
            _candyStoreRepository = candyStoreRepository;
            _stringBuilderFacade = stringBuilderFacade;
            _dateTimeFacade = dateTimeFacade;
        }

        public IReceiptView View { get; set; }

        public string GetReceiptText()
        {
            var order = _candyStoreRepository.GetAll<Order>()
                .FirstOrDefault(x => x.OrderID == View.OrderId);

            _stringBuilderFacade.AppendLine("Candy Store Receipt\n");
            _stringBuilderFacade.AppendLine("\n");
            _stringBuilderFacade.AppendLine($"Order: {order.OrderID.ToString()}");

            foreach (var item in Session.Products)
            {
                string currentLine = $"{item.Key.Name}  ${item.Key.Price:f2} x {item.Value}    ${item.Value * item.Key.Price:f2}";
                _stringBuilderFacade.AppendLine(currentLine);
            }

            var orderTotalPrice = _candyStoreRepository.GetAll<Order>()
                .FirstOrDefault(x => x.OrderID == View.OrderId)
                .TotalPrice;
            _stringBuilderFacade.AppendLine($"\nTotal price: {orderTotalPrice.ToString("0.00" + "$")}");

            _stringBuilderFacade.AppendLine($"\nCustomer: {Session.FirstName} {Session.LastName}");
            _stringBuilderFacade.AppendLine($"\nDate: {_dateTimeFacade.GetCurrentTime()}");

            return _stringBuilderFacade.ToString();
        }
    }
}
