using GMap.NET;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapa.Classes
{
    public abstract class MapObject
    {
        public string objectName;
        public DateTime creationTime;
        public MapObject(string name)
        {
            this.objectName = name;
            creationTime = DateTime.Now;
        }

        public abstract string getTitle();

        public abstract DateTime getCreationDate();

        public abstract double getDistance();

        public abstract PointLatLng getFocus();

        public abstract GMapMarker GetMarker();
                                 
    }
}
