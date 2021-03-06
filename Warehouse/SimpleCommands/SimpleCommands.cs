﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft;
using GalaSoft.MvvmLight;
using Telegrams;

namespace Warehouse.SimpleCommands
{
    // from ViewModelBase
    public class SimpleCommand : ViewModelBase
    {
        private static int IDENTITY_ID = 1;
        public enum EnumTask { Move = 11, Pick, Drop, Delete = 97, Create, Cancel }
        public enum EnumStatus { NotActive = 0, Written, InPlc, PLCFinished, PLCCanceled, Canceled, Finished }

        private int _ID;
        private int _Command_ID;
        private UInt32 _material;
        private EnumTask _task;
        private string _source;
        private EnumStatus _status;
        private DateTime _time;

        public SimpleCommand()
        {
            ID = IDENTITY_ID++;
        }

        public SimpleCommand(SimpleCommand scc)
        {
            ID = IDENTITY_ID++;
            this.Command_ID = scc.Command_ID;
            this.Status = scc.Status;
            this.Time = scc.Time;
            this.Task = scc.Task;
            this.Material = scc.Material;
            this.Source = scc.Source;
        }
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    RaisePropertyChanged("ID");
                }
            }
        }

        public int Command_ID
        {
            get { return _Command_ID; }
            set
            {
                if (_Command_ID != value)
                {
                    _Command_ID = value;
                    RaisePropertyChanged("Command_ID");
                }
            }
        }

        public UInt32 Material
        {
            get { return _material; }
            set
            {
                if (_material != value)
                {
                    _material = value;
                    RaisePropertyChanged("Material");
                }
            }
        }

        public EnumTask Task
        {
            get { return _task; }
            set
            {
                if (_task != value)
                {
                    _task = value;
                    RaisePropertyChanged("Task");
                }
            }
        }

        public string Source
        {
            get { return _source; }
            set
            {
                if (_source != value)
                {
                    _source = value;
                    RaisePropertyChanged("Source");
                }
            }
        }

        public EnumStatus Status
        {
            get { return _status; }
            set
            {
                if(_status != value)
                {
                    _status = value;
                    RaisePropertyChanged("Status");
                }
            }
        }

        public DateTime Time
        {
            get { return _time; }
            set
            {
                if (_time != value)
                {
                    _time = value;
                    RaisePropertyChanged("Time");
                }
            }
        }
    }

}
