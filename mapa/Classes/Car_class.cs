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
            return point;
        }

        public override DateTime getCreationDate()
        {
            throw new NotImplementedException();
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
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/car.png")) // картинка
                }
            };
            return marker;
        }

        public override string getTitle()
        {
            throw new NotImplementedException();
        }
    }
}
