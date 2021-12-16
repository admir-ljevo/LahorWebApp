using Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ResponseModel
    {
        public ResponseModel(ResponseCode responseCode,string responseMessage,object dataSet)
        {
            this.ResponseCode = responseCode;
            this.ResponseMessage = responseMessage;
            this.DataSet = dataSet;
        }
        public ResponseCode ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public object DataSet { get; set; }
    }
}
