using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NewsSearchService
{
    [ServiceContract]
    public interface INewsSearchService
    {
        [OperationContract]
        List<string> GetNews(string searchString);
    }
}
