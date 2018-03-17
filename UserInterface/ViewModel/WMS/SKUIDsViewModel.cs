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

namespace UserInterface.ViewModel
{
    public sealed class SKUIDsViewModel : ViewModelBase
    {
        public enum CommandType { None = 0, Add, Edit};

        #region members
        private CommandType _selectedCommand;
        private ObservableCollection<SKUIDViewModel> _SKUIDList;
        private SKUIDViewModel _selectedSKUID;
        private SKUIDViewModel _detailedSKUID;
        private SKUIDViewModel _manageSKUID;
        private bool _editEnabled;
        private bool _enabledCC;
        private BasicWarehouse _warehouse;
        private DBServiceWMS _dbservicewms;
        private int _accessLevel;
        #endregion

        #region properites
        public RelayCommand Add { get; private set; }
        public RelayCommand Edit { get; private set; }
        public RelayCommand Confirm { get; private set; }
        public RelayCommand Cancel { get; private set; }
        public RelayCommand Refresh { get; private set; }

        public ObservableCollection<SKUIDViewModel> SKUIDList
        {
            get { return _SKUIDList; }
            set
            {
                if (_SKUIDList != value)
                {
                    _SKUIDList = value;
                    RaisePropertyChanged("SKUIDList");
                }
            }
        }

        public SKUIDViewModel SelectedSKUID
        {
            get
            {
                return _selectedSKUID;
            }
            set
            {
                if (_selectedSKUID != value)
                {
                    _selectedSKUID = value;
                    RaisePropertyChanged("SelectedSKUID");
                    try
                    {
                        if (_selectedSKUID != null)
                            DetailedSKUID = SelectedSKUID;
                    }
                    catch (Exception e)
                    {
                        _warehouse.AddEvent(Database.Event.EnumSeverity.Error, Database.Event.EnumType.Exception, e.Message);
                        throw new Exception(string.Format("{0}.{1}: {2}", this.GetType().Name, (new StackTrace()).GetFrame(0).GetMethod().Name, e.Message));
                    }
                }
            }
        }

        public SKUIDViewModel DetailedSKUID
        {
            get { return _detailedSKUID; }
            set
            {
                if (_detailedSKUID != value)
                {
                    _detailedSKUID = value;
                    RaisePropertyChanged("DetailedSKUID");
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
        public SKUIDsViewModel()
        {
            DetailedSKUID = new SKUIDViewModel();
            SelectedSKUID = null;

            EditEnabled = false;
            EnabledCC = false;

            _selectedCommand = CommandType.None;

            Add = new RelayCommand(() => ExecuteAdd(), CanExecuteAdd);
            Edit = new RelayCommand(() => ExecuteEdit(), CanExecuteEdit);
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
                SKUIDList = new ObservableCollection<SKUIDViewModel>();
                foreach (var p in _dbservicewms.GetSKUIDs())
                    SKUIDList.Add(new SKUIDViewModel { ID = p.ID, Description = p.Description, DefaultQty = p.DefaultQty, Unit = p.Unit, Weight = p.Weight, FrequencyClass = p.FrequencyClass });
                foreach (var l in SKUIDList)
                    l.Initialize(_warehouse);
                DetailedSKUID.Initialize(_warehouse);
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
        private void ExecuteAdd()
        {
            try
            {
                EditEnabled = true;
                EnabledCC = true;
                _selectedCommand = CommandType.Add;
                _manageSKUID = new SKUIDViewModel{ID = "", Description = "", DefaultQty = 0,  Unit = "", Weight = 0, FrequencyClass = 1};
                _manageSKUID.Initialize(_warehouse);
                _manageSKUID.AllowChangeIndex = true;
                _manageSKUID.ValidationEnabled = true;
                DetailedSKUID = _manageSKUID;
            }
            catch (Exception e)
            {
                _warehouse.AddEvent(Database.Event.EnumSeverity.Error, Database.Event.EnumType.Exception,
                                    string.Format("{0}.{1}: {2}", this.GetType().Name, (new StackTrace()).GetFrame(0).GetMethod().Name, e.Message));
            }
        }
        private bool CanExecuteAdd()
        {
            try
            {
                return !EditEnabled && AccessLevel >= 1;
            }
            catch (Exception e)
            {
                _warehouse.AddEvent(Database.Event.EnumSeverity.Error, Database.Event.EnumType.Exception,
                                    string.Format("{0}.{1}: {2}", this.GetType().Name, (new StackTrace()).GetFrame(0).GetMethod().Name, e.Message));
                return false;
            }
        }
        private void ExecuteEdit()
        {
            try
            {
                EditEnabled = true;
                EnabledCC = true;                
                _selectedCommand = CommandType.Edit;
                _manageSKUID = new SKUIDViewModel {
                    ID = SelectedSKUID.ID,
                    Description = SelectedSKUID.Description,
                    DefaultQty = SelectedSKUID.DefaultQty,
                    Unit = SelectedSKUID.Unit,
                    Weight = SelectedSKUID.Weight,
                    FrequencyClass = SelectedSKUID.FrequencyClass
                };
                _manageSKUID.Initialize(_warehouse);
                _manageSKUID.ValidationEnabled = true;
                DetailedSKUID = _manageSKUID;
            }
            catch (Exception e)
            {
                _warehouse.AddEvent(Database.Event.EnumSeverity.Error, Database.Event.EnumType.Exception, 
                                    string.Format("{0}.{1}: {2}", this.GetType().Name, (new StackTrace()).GetFrame(0).GetMethod().Name, e.Message));
            }
        }

        private bool CanExecuteEdit()
        {
            try
            {
                return !EditEnabled && (SelectedSKUID != null) && AccessLevel >= 1;
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
                if (DetailedSKUID != null)
                {
                    DetailedSKUID.ValidationEnabled = false;
                }
                DetailedSKUID = SelectedSKUID;
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
                return EditEnabled;
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
                        case CommandType.Add:
                            _dbservicewms.AddSKUID(DetailedSKUID.SKUID);
                            SKUIDList.Add(DetailedSKUID);
                            SelectedSKUID = SKUIDList.FirstOrDefault(p => p.ID == DetailedSKUID.ID);
                            _warehouse.AddEvent(Event.EnumSeverity.Event, Event.EnumType.Material,
                                                String.Format("SKUID added: id: {0}", DetailedSKUID.ID));
                            break;
                        case CommandType.Edit:
                            _dbservicewms.UpdateSKUID(DetailedSKUID.SKUID);
                            _warehouse.AddEvent(Event.EnumSeverity.Event, Event.EnumType.Material,
                                                String.Format("SKUID changed: id: {0}", DetailedSKUID.ID));
                            SelectedSKUID.ID = DetailedSKUID.ID;
                            SelectedSKUID.Description = DetailedSKUID.Description;
                            SelectedSKUID.DefaultQty = DetailedSKUID.DefaultQty;
                            SelectedSKUID.Unit = DetailedSKUID.Unit;
                            SelectedSKUID.Weight = DetailedSKUID.Weight;
                            SelectedSKUID.FrequencyClass = DetailedSKUID.FrequencyClass;
                            break;
                        default:
                            break;
                    }
                    if (DetailedSKUID != null)
                        DetailedSKUID.ValidationEnabled = false;
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
                return EditEnabled && DetailedSKUID.AllPropertiesValid && AccessLevel >= 1;
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
                SKUIDViewModel sl = SelectedSKUID; 
                SKUIDList.Clear();
                foreach (var p in _dbservicewms.GetSKUIDs())
                    SKUIDList.Add(new SKUIDViewModel { ID = p.ID, Description = p.Description, DefaultQty = p.DefaultQty, Unit = p.Unit, Weight = p.Weight, FrequencyClass = p.FrequencyClass });
                foreach (var l in SKUIDList)
                    l.Initialize(_warehouse);
                if ( sl != null)
                    SelectedSKUID = SKUIDList.FirstOrDefault(p => p.ID == sl.ID);
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
                if (vm is SKUIDsViewModel)
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