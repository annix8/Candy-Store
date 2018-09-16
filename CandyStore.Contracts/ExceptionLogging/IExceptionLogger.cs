using System;

namespace CandyStore.Contracts.ExceptionLogging
{
    public interface IExceptionLogger
    {
        void Log(Exception exception);
    }
}
