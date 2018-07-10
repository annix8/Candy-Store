using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyStore.DataModel.CandyStoreModels
{
    public class DataValidationResult
    {
        public DataValidationResult()
        {
            ErrorMessages = new List<string>();
        }

        public bool Valid { get; set; }
        public IList<string> ErrorMessages { get; set; }
    }
}
