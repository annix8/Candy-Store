using System;
using CandyStore.Contracts.Client.Facades;
using CandyStore.Contracts.ExceptionLogging;
using CandyStore.Contracts.Infrastructure;
using CandyStore.DataModel.Models;

namespace CandyStore.Infrastructure.ExceptionLogging
{
    public class DatabaseExceptionLogger : IExceptionLogger
    {
        private readonly ICandyStoreRepository _candyStoreRepository;
        private readonly IDateTimeFacade _dateTimeFacade;

        public DatabaseExceptionLogger(ICandyStoreRepository candyStoreRepository,
            IDateTimeFacade dateTimeFacade)
        {
            _candyStoreRepository = candyStoreRepository;
            _dateTimeFacade = dateTimeFacade;
        }

        public void Log(Exception exception)
        {
            var exceptionToLog = new ExceptionLog
            {
                Date = _dateTimeFacade.GetCurrentTime(),
                Message = exception.Message,
                InnerException = exception.InnerException?.Message,
                StackTrace = exception.StackTrace
            };

            _candyStoreRepository.Insert(exceptionToLog);
        }
    }
}
