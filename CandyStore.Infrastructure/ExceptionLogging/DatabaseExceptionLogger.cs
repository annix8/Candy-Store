using System;
using CandyStore.Contracts.ExceptionLogging;

namespace CandyStore.Infrastructure.ExceptionLogging
{
    public class DatabaseExceptionLogger : IExceptionLogger
    {
        public void Log(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
