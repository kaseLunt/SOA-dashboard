﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.StockBuildServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StockBuildServiceRef.IStockBuildService")]
    public interface IStockBuildService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockBuildService/StockBuild", ReplyAction="http://tempuri.org/IStockBuildService/StockBuildResponse")]
        string StockBuild(string symbol);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockBuildService/StockBuild", ReplyAction="http://tempuri.org/IStockBuildService/StockBuildResponse")]
        System.Threading.Tasks.Task<string> StockBuildAsync(string symbol);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStockBuildServiceChannel : Client.StockBuildServiceRef.IStockBuildService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StockBuildServiceClient : System.ServiceModel.ClientBase<Client.StockBuildServiceRef.IStockBuildService>, Client.StockBuildServiceRef.IStockBuildService {
        
        public StockBuildServiceClient() {
        }
        
        public StockBuildServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StockBuildServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockBuildServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockBuildServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string StockBuild(string symbol) {
            return base.Channel.StockBuild(symbol);
        }
        
        public System.Threading.Tasks.Task<string> StockBuildAsync(string symbol) {
            return base.Channel.StockBuildAsync(symbol);
        }
    }
}
