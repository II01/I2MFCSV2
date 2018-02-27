﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Warehouse.WCF_RcvTelProxy {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCF_RcvTelProxy.IWCF_RcvTelProxy", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IWCF_RcvTelProxy {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCF_RcvTelProxy/Init", ReplyAction="http://tempuri.org/IWCF_RcvTelProxy/InitResponse")]
        void Init(string name, string addr, int SendPort, int timeoutSec, string version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCF_RcvTelProxy/Init", ReplyAction="http://tempuri.org/IWCF_RcvTelProxy/InitResponse")]
        System.Threading.Tasks.Task InitAsync(string name, string addr, int SendPort, int timeoutSec, string version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCF_RcvTelProxy/Read", ReplyAction="http://tempuri.org/IWCF_RcvTelProxy/ReadResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Telegrams.TelegramCraneStatus))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Telegrams.TelegramCraneTO))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Telegrams.TelegramTransportTO))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Telegrams.TelegramTransportStatus))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Telegrams.TelegramTransportSetTime))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Telegrams.TelegramLife))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Telegrams.TelegramACK))]
        Telegrams.Telegram Read();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCF_RcvTelProxy/Read", ReplyAction="http://tempuri.org/IWCF_RcvTelProxy/ReadResponse")]
        System.Threading.Tasks.Task<Telegrams.Telegram> ReadAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWCF_RcvTelProxyChannel : Warehouse.WCF_RcvTelProxy.IWCF_RcvTelProxy, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WCF_RcvTelProxyClient : System.ServiceModel.ClientBase<Warehouse.WCF_RcvTelProxy.IWCF_RcvTelProxy>, Warehouse.WCF_RcvTelProxy.IWCF_RcvTelProxy {
        
        public WCF_RcvTelProxyClient() {
        }
        
        public WCF_RcvTelProxyClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WCF_RcvTelProxyClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCF_RcvTelProxyClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCF_RcvTelProxyClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Init(string name, string addr, int SendPort, int timeoutSec, string version) {
            base.Channel.Init(name, addr, SendPort, timeoutSec, version);
        }
        
        public System.Threading.Tasks.Task InitAsync(string name, string addr, int SendPort, int timeoutSec, string version) {
            return base.Channel.InitAsync(name, addr, SendPort, timeoutSec, version);
        }
        
        public Telegrams.Telegram Read() {
            return base.Channel.Read();
        }
        
        public System.Threading.Tasks.Task<Telegrams.Telegram> ReadAsync() {
            return base.Channel.ReadAsync();
        }
    }
}
