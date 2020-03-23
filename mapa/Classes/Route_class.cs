using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Device.Location;
using System.Windows.Forms;
using mapa.Classes;

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
            GMapMarker marker = new GMapRoute(points)
            {
                Shape = new Path()
                {
                    Stroke = Brushes.DarkBlue, // цвет обводки
                    Fill = Brushes.DarkBlue, // цвет заливки
                    StrokeThickness = 4 // толщина обводки
                }
            };
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
