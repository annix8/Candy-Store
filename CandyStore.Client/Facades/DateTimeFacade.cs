using System;
using CandyStore.Contracts.Client.Facades;

namespace CandyStore.Client.Facades
{
    public class DateTimeFacade : IDateTimeFacade
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
