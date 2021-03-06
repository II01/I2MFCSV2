﻿using Database;
using System;
using Telegrams;
using Warehouse.Model;

namespace Warehouse.ConveyorUnits
{
    // only status telegram possible
    public class MainPanel : Conveyor
    {
        public MainPanel() : base()
        {
            InitialNotified = true;
        }

        public override void OnTelegramTransportTO(Telegram t)
        {
        }

        public override void Initialize(BasicWarehouse w)
        {
            try
            {
                Warehouse = w;
                Communicator = Warehouse.Communicator[CommunicatorName];
                if (ConveyorInfo != null)
                {
                    ConveyorInfo.Name = Name;
                    ConveyorInfo.Initialize();
                }
            }
            catch (Exception ex)
            {
                Warehouse.AddEvent(Event.EnumSeverity.Error, Event.EnumType.Exception, ex.Message);
                throw new ConveyorException(String.Format("{0} MainPanel.Initialize failed", Name));
            }
        }

    }
}
