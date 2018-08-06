using CandyStore.Client.Util;
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
        private readonly ISession _session;

        public ReceiptPresenter(ICandyStoreRepository candyStoreRepository,
            IStringBuilderFacade stringBuilderFacade,
            IDateTimeFacade dateTimeFacade,
            ISession session)
        {
            _candyStoreRepository = candyStoreRepository;
            _stringBuilderFacade = stringBuilderFacade;
            _dateTimeFacade = dateTimeFacade;
            _session = session;
        }

        public IReceiptView View { get; set; }

        public string GetReceiptText()
        {
            _stringBuilderFacade.AppendLine("Candy Store Receipt");
            _stringBuilderFacade.AppendLine("\n");
            _stringBuilderFacade.AppendLine($"Order: {View.OrderId.ToString()}");

            var purchasedProducts = (from order in _candyStoreRepository.GetAll<Order>().Where(x => x.OrderID == View.OrderId)
                                    join orderDetail in _candyStoreRepository.GetAll<OrderDetails>()
                                    on order.OrderID equals orderDetail.OrderId
                                    into joinedOrderDetails
                                    from joinedOrderDetail in joinedOrderDetails
                                    join product in _candyStoreRepository.GetAll<Product>()
                                    on joinedOrderDetail.ProductId equals product.ProductID
                                    select new
                                    {
                                        Product = product,
                                        Quantity = joinedOrderDetail.ProductQuantity
                                    })
                                    .ToDictionary(x => x.Product, x => x.Quantity);

            foreach (var item in purchasedProducts)
            {
                string currentLine = $"{item.Key.Name}  ${item.Key.Price:f2} x {item.Value}    ${item.Value * item.Key.Price:f2}";
                _stringBuilderFacade.AppendLine(currentLine);
            }

            var orderTotalPrice = _candyStoreRepository.GetAll<Order>()
                .FirstOrDefault(x => x.OrderID == View.OrderId)
                .TotalPrice;
            _stringBuilderFacade.AppendLine($"\nTotal price: {orderTotalPrice.ToString("0.00" + "$")}");

            _stringBuilderFacade.AppendLine($"\nCustomer: {_session.Get<string>(Constants.FIRST_NAME_KEY)} {_session.Get<string>(Constants.LAST_NAME_KEY)}");
            _stringBuilderFacade.AppendLine($"\nDate: {_dateTimeFacade.GetCurrentTime()}");

            return _stringBuilderFacade.ToString();
        }
    }
}
