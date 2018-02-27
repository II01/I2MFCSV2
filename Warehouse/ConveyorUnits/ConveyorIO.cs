﻿using System.Collections.Generic;
using System.Xml.Serialization;
using Warehouse.Common;

namespace Warehouse.ConveyorUnits
{

    // define Conveyor with communication to Crane
    public interface IConveyorIO
    {
        LPosition CraneAddress { get; set; }

        string Name { get; set; }
    }

    public class ConveyorIO : ConveyorJunction, IConveyorIO
    {
        [XmlIgnore]
        public List<Model.BasicWarehouse.Route> FinalRouteCost { get; set; }

        public LPosition CraneAddress { get; set; } // crane adress 
    }
}
