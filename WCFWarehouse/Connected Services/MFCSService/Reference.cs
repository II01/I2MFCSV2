﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFWarehouse.MFCSService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MFCSService.INotifyUI", CallbackContract=typeof(WCFWarehouse.MFCSService.INotifyUICallback))]
    public interface INotifyUI {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INotifyUI/UIRegister", ReplyAction="http://tempuri.org/INotifyUI/UIRegisterResponse")]
        void UIRegister(string communicatorName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INotifyUI/UIRegister", ReplyAction="http://tempuri.org/INotifyUI/UIRegisterResponse")]
        System.Threading.Tasks.Task UIRegisterAsync(string communicatorName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INotifyUI/UIUnRegister", ReplyAction="http://tempuri.org/INotifyUI/UIUnRegisterResponse")]
        void UIUnRegister(string communicatorName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INotifyUI/UIUnRegister", ReplyAction="http://tempuri.org/INotifyUI/UIUnRegisterResponse")]
        System.Threading.Tasks.Task UIUnRegisterAsync(string communicatorName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/SetMode")]
        void SetMode(bool remote, bool automatic, bool run);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/SetMode")]
        System.Threading.Tasks.Task SetModeAsync(bool remote, bool automatic, bool run);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/Reset")]
        void Reset(string segment);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/Reset")]
        System.Threading.Tasks.Task ResetAsync(string segment);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/Info")]
        void Info(string segment);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/Info")]
        System.Threading.Tasks.Task InfoAsync(string segment);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/AutoOn")]
        void AutoOn(string segment);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/AutoOn")]
        System.Threading.Tasks.Task AutoOnAsync(string segment);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/AutoOff")]
        void AutoOff(string segment);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/AutoOff")]
        System.Threading.Tasks.Task AutoOffAsync(string segment);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/LongTermBlockOn")]
        void LongTermBlockOn(string segment);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/LongTermBlockOn")]
        System.Threading.Tasks.Task LongTermBlockOnAsync(string segment);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/RebuildRoutes")]
        void RebuildRoutes(bool ignoreBlocked);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/RebuildRoutes")]
        System.Threading.Tasks.Task RebuildRoutesAsync(bool ignoreBlocked);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INotifyUI/RouteExists", ReplyAction="http://tempuri.org/INotifyUI/RouteExistsResponse")]
        bool RouteExists(string source, string target, bool isSimpleCommand);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INotifyUI/RouteExists", ReplyAction="http://tempuri.org/INotifyUI/RouteExistsResponse")]
        System.Threading.Tasks.Task<bool> RouteExistsAsync(string source, string target, bool isSimpleCommand);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/LongTermBlockOff")]
        void LongTermBlockOff(string segment);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/LongTermBlockOff")]
        System.Threading.Tasks.Task LongTermBlockOffAsync(string segment);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/SetClock")]
        void SetClock(string segment);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/SetClock")]
        System.Threading.Tasks.Task SetClockAsync(string segment);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/PlaceIDChanged")]
        void PlaceIDChanged(Database.PlaceID place);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/PlaceIDChanged")]
        System.Threading.Tasks.Task PlaceIDChangedAsync(Database.PlaceID place);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INotifyUICallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/UIConveyorBasicUINotify")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Warehouse.ConveyorUnits.CraneInfo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Warehouse.ConveyorUnits.ConveyorInfo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Warehouse.ConveyorUnits.SegmentInfo))]
        void UIConveyorBasicUINotify(Warehouse.ConveyorUnits.ConveyorBasicInfo c);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/UIAddEvent")]
        void UIAddEvent(System.DateTime time, Database.Event.EnumSeverity s, Database.Event.EnumType t, string text);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/INotifyUI/SystemMode")]
        void SystemMode(bool remote, bool automatic, bool run);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INotifyUIChannel : WCFWarehouse.MFCSService.INotifyUI, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NotifyUIClient : System.ServiceModel.DuplexClientBase<WCFWarehouse.MFCSService.INotifyUI>, WCFWarehouse.MFCSService.INotifyUI {
        
        public NotifyUIClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public NotifyUIClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public NotifyUIClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public NotifyUIClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public NotifyUIClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void UIRegister(string communicatorName) {
            base.Channel.UIRegister(communicatorName);
        }
        
        public System.Threading.Tasks.Task UIRegisterAsync(string communicatorName) {
            return base.Channel.UIRegisterAsync(communicatorName);
        }
        
        public void UIUnRegister(string communicatorName) {
            base.Channel.UIUnRegister(communicatorName);
        }
        
        public System.Threading.Tasks.Task UIUnRegisterAsync(string communicatorName) {
            return base.Channel.UIUnRegisterAsync(communicatorName);
        }
        
        public void SetMode(bool remote, bool automatic, bool run) {
            base.Channel.SetMode(remote, automatic, run);
        }
        
        public System.Threading.Tasks.Task SetModeAsync(bool remote, bool automatic, bool run) {
            return base.Channel.SetModeAsync(remote, automatic, run);
        }
        
        public void Reset(string segment) {
            base.Channel.Reset(segment);
        }
        
        public System.Threading.Tasks.Task ResetAsync(string segment) {
            return base.Channel.ResetAsync(segment);
        }
        
        public void Info(string segment) {
            base.Channel.Info(segment);
        }
        
        public System.Threading.Tasks.Task InfoAsync(string segment) {
            return base.Channel.InfoAsync(segment);
        }
        
        public void AutoOn(string segment) {
            base.Channel.AutoOn(segment);
        }
        
        public System.Threading.Tasks.Task AutoOnAsync(string segment) {
            return base.Channel.AutoOnAsync(segment);
        }
        
        public void AutoOff(string segment) {
            base.Channel.AutoOff(segment);
        }
        
        public System.Threading.Tasks.Task AutoOffAsync(string segment) {
            return base.Channel.AutoOffAsync(segment);
        }
        
        public void LongTermBlockOn(string segment) {
            base.Channel.LongTermBlockOn(segment);
        }
        
        public System.Threading.Tasks.Task LongTermBlockOnAsync(string segment) {
            return base.Channel.LongTermBlockOnAsync(segment);
        }
        
        public void RebuildRoutes(bool ignoreBlocked) {
            base.Channel.RebuildRoutes(ignoreBlocked);
        }
        
        public System.Threading.Tasks.Task RebuildRoutesAsync(bool ignoreBlocked) {
            return base.Channel.RebuildRoutesAsync(ignoreBlocked);
        }
        
        public bool RouteExists(string source, string target, bool isSimpleCommand) {
            return base.Channel.RouteExists(source, target, isSimpleCommand);
        }
        
        public System.Threading.Tasks.Task<bool> RouteExistsAsync(string source, string target, bool isSimpleCommand) {
            return base.Channel.RouteExistsAsync(source, target, isSimpleCommand);
        }
        
        public void LongTermBlockOff(string segment) {
            base.Channel.LongTermBlockOff(segment);
        }
        
        public System.Threading.Tasks.Task LongTermBlockOffAsync(string segment) {
            return base.Channel.LongTermBlockOffAsync(segment);
        }
        
        public void SetClock(string segment) {
            base.Channel.SetClock(segment);
        }
        
        public System.Threading.Tasks.Task SetClockAsync(string segment) {
            return base.Channel.SetClockAsync(segment);
        }
        
        public void PlaceIDChanged(Database.PlaceID place) {
            base.Channel.PlaceIDChanged(place);
        }
        
        public System.Threading.Tasks.Task PlaceIDChangedAsync(Database.PlaceID place) {
            return base.Channel.PlaceIDChangedAsync(place);
        }
    }
}