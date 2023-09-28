using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StockQuoteService
{
    [ServiceContract]
    public interface IStockQuoteService
    {

        [OperationContract]
        string StockQuote(string stock);
    }
}
