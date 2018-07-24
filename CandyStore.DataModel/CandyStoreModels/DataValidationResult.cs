using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyStore.DataModel.CandyStoreModels
{
    public class DataValidationResult
    {
        private IList<string> _errorMessages;

        public DataValidationResult()
        {
            _errorMessages = new List<string>();
        }

        public bool Valid { get; set; }
        public object Object { get; set; }

        public void AddErrorMessage(string message)
        {
            _errorMessages.Add(message);
        }

        public string GetAllErrorMessages()
        {
            return string.Join(", ", _errorMessages);
        }
    }
}
