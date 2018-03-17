﻿using System;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using UserInterface.Services;
using Database;
using Warehouse.Model;
using System.Diagnostics;
using GalaSoft.MvvmLight.Messaging;
using UserInterface.Messages;
using WCFClients;
using UserInterface.DataServiceWMS;
using System.Collections.Generic;
using DatabaseWMS;

namespace UserInterface.ViewModel
{
    public sealed class CommandWMSsViewModel : ViewModelBase
    {
        public enum CommandType { None = 0, Edit, Book, Delete, Add};

        #region members
        private CommandType _selectedCommand;
        private ObservableCollection<CommandWMSViewModel> _dataList;
        private CommandWMSViewModel _selected;
        private CommandWMSViewModel _detailed;
        private bool _editEnabled;
        private bool _enabledCC;
        private BasicWarehouse _warehouse;
        private DBServiceWMS _dbservicewms;
        private int _accessLevel;
        #endregion

        #region properites
        public RelayCommand Delete { get; private set; }
        public RelayCommand Confirm { get; private set; }
        public RelayCommand Cancel { get; private set; }
        public RelayCommand Refresh { get; private set; }

        public ObservableCollection<CommandWMSViewModel> DataList
        {
            get { return _dataList; }
            set
            {
                if (_dataList != value)
                {
                    _dataList = value;
                    RaisePropertyChanged("DataList");
                }
            }
        }

        public CommandWMSViewModel Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    RaisePropertyChanged("Selected");
                    try
                    {
                        if (_selected != null)
                            Detailed = Selected;
                    }
                    catch (Exception e)
                    {
                        _warehouse.AddEvent(Database.Event.EnumSeverity.Error, Database.Event.EnumType.Exception, e.Message);
                        throw new Exception(string.Format("{0}.{1}: {2}", this.GetType().Name, (new StackTrace()).GetFrame(0).GetMethod().Name, e.Message));
                    }
                }
            }
        }

        public CommandWMSViewModel Detailed
        {
            get { return _detailed; }
            set
            {
                if (_detailed != value)
                {
                    _detailed = value;
                    RaisePropertyChanged("Detailed");
                }
            }
        }

        public bool EditEnabled
        {
            get { return _editEnabled; }
            set
            {
                if (_editEnabled != value)
                {
                    _editEnabled = value;
                    RaisePropertyChanged("EditEnabled");
                }
            }
        }
        public bool EnabledCC
        {
            get { return _enabledCC; }
            set
            {
                if (_enabledCC != value)
                {
                    _enabledCC = value;
                    RaisePropertyChanged("EnabledCC");
                }
            }
        }
        public int AccessLevel
        {
            get
            {
                return _accessLevel;
            }
            set
            {
                if (_accessLevel != value)
                {
                    _accessLevel = value;
                    RaisePropertyChanged("AccessLevel");
                }
            }
        }
        #endregion

        #region initialization
        public CommandWMSsViewModel()
        {
            Detailed = null;
            Selected = null;

            EditEnabled = false;
            EnabledCC = false;

            _selectedCommand = CommandType.None;

            Delete = new RelayCommand(() => ExecuteDelete(), CanExecuteDelete);
            Cancel = new RelayCommand(() => ExecuteCancel(), CanExecuteCancel);
            Confirm = new RelayCommand(() => ExecuteConfirm(), CanExecuteConfirm);
            Refresh = new RelayCommand(() => ExecuteRefresh());
        }

        public void Initialize(BasicWarehouse warehouse)
        {
            _warehouse = warehouse;
            _dbservicewms = new DBServiceWMS(_warehouse);
            try
            {
                DataList = new ObservableCollection<CommandWMSViewModel>();
                foreach (var p in _dbservicewms.GetCommandOrders((int)EnumCommandWMSStatus.Finished))
                    DataList.Add(new CommandWMSViewModel
                    {
                        WMSID = p.ID,
                        OrderID = p.Order_ID,
                        TUID = p.TU_ID,
                        Source = p.Source,
                        Target = p.Target,
                        Status = (EnumCommandWMSStatus)p.Status,
                        OrderERPID = p.OrderERPID,
                        OrderOrderID = p.OrderOrderID,
                        OrderSubOrderID = p.OrderSubOrderID,
                        OrderSubOrderName = p.OrderSubOrderName,
                        OrderSKUID = p.OrderSKUID,
                        OrderSKUBatch = p.OrderSKUBatch
                    });
                foreach (var l in DataList)
                    l.Initialize(_warehouse);
                Messenger.Default.Register<MessageAccessLevel>(this, (mc) => { AccessLevel = mc.AccessLevel; });
                Messenger.Default.Register<MessageViewChanged>(this, vm => ExecuteViewActivated(vm.ViewModel));
            }
            catch (Exception e)
            {
                _warehouse.AddEvent(Database.Event.EnumSeverity.Error, Database.Event.EnumType.Exception, e.Message);
                throw new Exception(string.Format("{0}.{1}: {2}", this.GetType().Name, (new StackTrace()).GetFrame(0).GetMethod().Name, e.Message));
            }
        }
        #endregion

        #region commands

        private void ExecuteDelete()
        {
            try
            {
                _selectedCommand = CommandType.Delete;
                EditEnabled = false;
                EnabledCC = true;
                Detailed = new CommandWMSViewModel();
                Detailed.Initialize(_warehouse);
                Detailed.ValidationEnabled = true;
                Detailed.WMSID = Selected.WMSID;
                Detailed.OrderID = Selected.OrderID;
                Detailed.TUID = Selected.TUID;
                Detailed.Source = Selected.Source;
                Detailed.Target = Selected.Target;
                Detailed.Status = Selected.Status;
                Detailed.OrderERPID = Selected.OrderERPID;
                Detailed.OrderOrderID = Selected.OrderOrderID;
                Detailed.OrderSubOrderID = Selected.OrderSubOrderID;
                Detailed.OrderSubOrderName = Selected.OrderSubOrderName;
                Detailed.OrderSKUID = Selected.OrderSKUID;
                Detailed.OrderSKUBatch = Selected.OrderSKUBatch;
            }
            catch (Exception e)
            {
                _warehouse.AddEvent(Database.Event.EnumSeverity.Error, Database.Event.EnumType.Exception,
                                    string.Format("{0}.{1}: {2}", this.GetType().Name, (new StackTrace()).GetFrame(0).GetMethod().Name, e.Message));
            }
        }

        private bool CanExecuteDelete()
        {
            try
            {
                return !EditEnabled && (Selected != null) && AccessLevel >= 1;
            }
            catch (Exception e)
            {
                _warehouse.AddEvent(Database.Event.EnumSeverity.Error, Database.Event.EnumType.Exception,
                                    string.Format("{0}.{1}: {2}", this.GetType().Name, (new StackTrace()).GetFrame(0).GetMethod().Name, e.Message));
                return false;
            }

        }
        private void ExecuteCancel()
        {
            try
            {
                EditEnabled = false;
                EnabledCC = false;
                if (Detailed != null)
                    Detailed.ValidationEnabled = false;
                Detailed = Selected;
            }
            catch (Exception e)
            {
                _warehouse.AddEvent(Database.Event.EnumSeverity.Error, Database.Event.EnumType.Exception, e.Message);
            }
        }
        private bool CanExecuteCancel()
        {
            try
            {
                return EnabledCC;
            }
            catch (Exception e)
            {
                _warehouse.AddEvent(Database.Event.EnumSeverity.Error, Database.Event.EnumType.Exception, 
                                    string.Format("{0}.{1}: {2}", this.GetType().Name, (new StackTrace()).GetFrame(0).GetMethod().Name, e.Message));
                return false;
            }
        }

        private void ExecuteConfirm()
        {
            try
            {
                EditEnabled = false;
                EnabledCC = false;
                try
                {
                    switch (_selectedCommand)
                    {
                        case CommandType.Delete:
                            _dbservicewms.UpdateCommand(new Commands
                                {
                                    ID = Detailed.WMSID,
                                    Order_ID = Detailed.OrderID,
                                    TU_ID = Detailed.TUID,
                                    Source = Detailed.Source,
                                    Target = Detailed.Target,
                                    Status = (int)EnumCommandWMSStatus.Canceled
                                });
                            Detailed.Status = EnumCommandWMSStatus.Canceled;
                            Selected.Status = Detailed.Status;
                            break;
                        default:
                            break;
                    }
                    if (Detailed != null)
                        Detailed.ValidationEnabled = false;
                }
                catch (Exception e)
                {
                    _warehouse.AddEvent(Event.EnumSeverity.Error, Event.EnumType.Exception, e.Message);
                }
            }
            catch (Exception e)
            {
                _warehouse.AddEvent(Database.Event.EnumSeverity.Error, Database.Event.EnumType.Exception, 
                                    string.Format("{0}.{1}: {2}", this.GetType().Name, (new StackTrace()).GetFrame(0).GetMethod().Name, e.Message));
            }
        }
        private bool CanExecuteConfirm()
        {
            try
            {
                return (EditEnabled && Detailed.AllPropertiesValid && AccessLevel >= 1) || _selectedCommand == CommandType.Delete;
            }
            catch (Exception e)
            {
                _warehouse.AddEvent(Database.Event.EnumSeverity.Error, Database.Event.EnumType.Exception, 
                                    string.Format("{0}.{1}: {2}", this.GetType().Name, (new StackTrace()).GetFrame(0).GetMethod().Name, e.Message));
                return false;
            }
        }
        private void ExecuteRefresh()
        {
            try
            {
                int? wmsid = Selected?.WMSID;
                DataList.Clear();
                foreach (var p in _dbservicewms.GetCommandOrders((int)EnumCommandWMSStatus.Finished))
                    DataList.Add(new CommandWMSViewModel
                    {
                        WMSID = p.ID,
                        OrderID = p.Order_ID,
                        TUID = p.TU_ID,
                        Source = p.Source,
                        Target = p.Target,
                        Status = (EnumCommandWMSStatus)p.Status,
                        OrderERPID = p.OrderERPID,
                        OrderOrderID = p.OrderOrderID,
                        OrderSubOrderID = p.OrderSubOrderID,
                        OrderSubOrderName = p.OrderSubOrderName,
                        OrderSKUID = p.OrderSKUID,
                        OrderSKUBatch = p.OrderSKUBatch
                    });
                foreach (var l in DataList)
                    l.Initialize(_warehouse);
                if ( wmsid != null)
                    Selected = DataList.FirstOrDefault(p => p.WMSID == wmsid);
            }
            catch (Exception e)
            {
                _warehouse.AddEvent(Database.Event.EnumSeverity.Error, Database.Event.EnumType.Exception, 
                                    string.Format("{0}.{1}: {2}", this.GetType().Name, (new StackTrace()).GetFrame(0).GetMethod().Name, e.Message));
            }
        }
        #endregion
        public void ExecuteViewActivated(ViewModelBase vm)
        {
            try
            {
                if (vm is PlaceIDsViewModel)
                {
                    ExecuteRefresh();
                }
            }
            catch (Exception e)
            {
                _warehouse.AddEvent(Event.EnumSeverity.Error, Event.EnumType.Exception,
                                    string.Format("{0}.{1}: {2}", this.GetType().Name, (new StackTrace()).GetFrame(0).GetMethod().Name, e.Message));
            }
        }
    }
}