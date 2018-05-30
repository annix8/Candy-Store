using CandyStore.DataModel.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyStore.DataModel.Models
{
    public class Employee : IRelatedToCandyStoreDbContext
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Index(IsUnique= true)]
        public int IdentificationNumber { get; set; }
    }
}
