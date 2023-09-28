using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StockBuildService
{
    [ServiceContract]
    public interface IStockBuildService
    {
        [OperationContract]
        string StockBuild(string symbol);
    }
}
