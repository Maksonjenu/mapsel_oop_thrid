using GMap.NET;
using GMap.NET.WindowsPresentation;
using mapa.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace mapa
{
    class Route_class : MapObject
    {
        public List<PointLatLng> points = new List<PointLatLng>();
        public Route_class(string name, List<PointLatLng> Points) : base(name)
        
        {
            this.points = Points;        
        } 

       public override double getDistance()
        {
            return (new double());
        }

        public override PointLatLng getFocus()
        {
            return (new PointLatLng());
        }

        public override GMapMarker GetMarker()
        {
            GMapMarker marker = new GMapMarker(points[0]);
            return marker;
        }

        public override DateTime getCreationDate()
        {
            return new DateTime();
        }

        public override string getTitle()
        {
            throw new NotImplementedException();
        }

        /*
        GMapMarker getMarker()
        {
            return (new GMapMarker());
        }
        */
    }
}
