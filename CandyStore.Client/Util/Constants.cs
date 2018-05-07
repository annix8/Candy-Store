using CandyStore.Client.OrderServiceProxy;

namespace CandyStore.Client.Util
{
    public static class Constants
    {
        public const string Address = "Example address";
        public const string PhoneNumber = "1234567890";
        public static CustomerDto Customer
        {
            get
            {
                return new CustomerDto
                {
                    Address = Address,
                    IdentificationNumber = "123-456-789",
                    Name = "Candy Store",
                    PhoneNumber = PhoneNumber
                };
            }
        }
    }
}
