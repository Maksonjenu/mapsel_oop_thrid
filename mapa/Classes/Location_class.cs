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
    class Location_class : MapObject
    {
        PointLatLng point = new PointLatLng();

        public Location_class(string name, PointLatLng Point) : base(name)
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

        public override GMapMarker GetMarker()
        {
            GMapMarker marker = new GMapMarker(point)
            {
                Shape = new Image
                {
                    Width = 32, // ширина маркера
                    Height = 32, // высота маркера
                    ToolTip = "машина", // всплывающая подсказка
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/point.png")) // картинка
                }
            };
            return marker;
        }

        public override DateTime getCreationDate()
        {
            throw new NotImplementedException();
        }

        public override string getTitle()
        {
            throw new NotImplementedException();
        }
        
    }
}
