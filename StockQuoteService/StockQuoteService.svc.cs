using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
//StockQuoteService.svc.cs
namespace StockQuoteService
{
    public class StockQuoteService : IStockQuoteService
    {
        public string StockQuote(string stock)
        {
            return $"You entered: {stock.ToUpper()}";
        }
    }
}
