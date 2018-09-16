using CandyStore.DataModel.Interfaces;
using System;

namespace CandyStore.DataModel.Models
{
    public class ExceptionLog : IRelatedToCandyStoreDbContext
    {
        public int ExceptionLogID { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
    }
}
