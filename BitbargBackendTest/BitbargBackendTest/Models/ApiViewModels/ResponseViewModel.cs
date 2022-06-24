using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitbargBackendTest.Models.ApiViewModels
{

    public class ResponseViewModel
    {

        public ResponseViewModel(string message, string error, dynamic result)
        {
            Message = message;
            Error = error;
            Result = result;
        }

        public string Message { get; set; }

        public string Error { get; set; }

        public dynamic Result { get; set; }

        public string ApiVersion => "1.0.0";

        public bool Success => string.IsNullOrEmpty(Error);

        public static ResponseViewModel CreateResponse(string message, string error, dynamic result)
        {
            return new ResponseViewModel(message, error, result);
        }
    }
}
