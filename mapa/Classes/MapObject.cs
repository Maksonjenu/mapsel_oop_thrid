﻿using GMap.NET;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapa.Classes
{
    interface IPOJALUSTA
    {
        double getDist();
       
    }
    public abstract class MapObject 
    {
        public string objectName;
        public DateTime creationTime;
        public MapObject(string name)
        {
            this.objectName = name;
            creationTime = DateTime.Now;
        }

        public string getTitle() => objectName;

        public DateTime getCreationDate() => creationTime;


        public abstract PointLatLng getFocus();

        public abstract GMapMarker GetMarker();

        public abstract double getDist(PointLatLng point);
        
            
    }
}
