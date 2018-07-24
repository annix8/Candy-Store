using System.Collections.Generic;

namespace CandyStore.DataModel.CandyStoreModels
{
    public class OperationValidationResult
    {
        private IList<string> _errorMessages;

        public OperationValidationResult()
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
