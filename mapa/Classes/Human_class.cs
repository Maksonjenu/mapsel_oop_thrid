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
    class Human_class : MapObject
    {
        PointLatLng point = new PointLatLng();

        public Human_class(string name,PointLatLng Point):base(name)
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

        public override string getTitle()
        {
            throw new NotImplementedException();
        }
        public override DateTime getCreationDate()
        {
            throw new NotImplementedException();
        }
        public override GMapMarker GetMarker()
        {
            throw new NotImplementedException();
        }
    }
}
