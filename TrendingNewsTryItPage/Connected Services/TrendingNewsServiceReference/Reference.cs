﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrendingNewsTryItPage.TrendingNewsServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TrendingNewsServiceReference.ITrendingNewsService")]
    public interface ITrendingNewsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrendingNewsService/GetTrendingNews", ReplyAction="http://tempuri.org/ITrendingNewsService/GetTrendingNewsResponse")]
        string[] GetTrendingNews();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrendingNewsService/GetTrendingNews", ReplyAction="http://tempuri.org/ITrendingNewsService/GetTrendingNewsResponse")]
        System.Threading.Tasks.Task<string[]> GetTrendingNewsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITrendingNewsServiceChannel : TrendingNewsTryItPage.TrendingNewsServiceReference.ITrendingNewsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TrendingNewsServiceClient : System.ServiceModel.ClientBase<TrendingNewsTryItPage.TrendingNewsServiceReference.ITrendingNewsService>, TrendingNewsTryItPage.TrendingNewsServiceReference.ITrendingNewsService {
        
        public TrendingNewsServiceClient() {
        }
        
        public TrendingNewsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TrendingNewsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TrendingNewsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TrendingNewsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetTrendingNews() {
            return base.Channel.GetTrendingNews();
        }
        
        public System.Threading.Tasks.Task<string[]> GetTrendingNewsAsync() {
            return base.Channel.GetTrendingNewsAsync();
        }
    }
}
