using GMap.NET;
using GMap.NET.WindowsForms;
using mapa.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapa
{
    class Car_class : MapObject
    {
        PointLatLng point = new PointLatLng();

        public Car_class(string name,PointLatLng Point):base(name)
        {
            this.point = Point;
        }
       
       public override double getDistance()
        {
            return (new double());
        }

        public override PointLatLng getFocus()
        {
            return (new PointLatLng());
        }

        public override DateTime getCreationDate()
        {
            throw new NotImplementedException();
        }

        public override GMapMarker GetMarker()
        {
            throw new NotImplementedException();
        }

        public override string getTitle()
        {
            throw new NotImplementedException();
        }
    }
}
