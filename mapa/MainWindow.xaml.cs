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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<PointLatLng> areaspots = new List<PointLatLng>();
        public static List<PointLatLng> pathspot = new List<PointLatLng>();
        public List<MapObject> mapObjects = new List<MapObject>();
        public PointLatLng point = new PointLatLng();
        public bool getareagreatagain = false;
        public bool getpathgreatagain = false;
       


        public MainWindow()
        {
           InitializeComponent();
           initMap();
            radioButCreate.IsChecked = true;
        }

        public void initMap()
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            Map.MapProvider = OpenStreetMapProvider.Instance;
            Map.MinZoom = 2;
            Map.MaxZoom = 17;
            Map.Zoom = 15;
            Map.Position = new PointLatLng(55.012823, 82.950359);
            Map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            Map.CanDragMap = true;
            Map.DragButton = MouseButton.Left;

        }
        
        public void createCarMarker(PointLatLng clickedPoint)
        {
            MapObject mapObject_car = new Car_class(createObjectName.Text,clickedPoint);
            mapObjects.Add(mapObject_car);
            Map.Markers.Add(mapObject_car.GetMarker());
        }

        public void createPeopleMarker(PointLatLng clickedPoint)
        {
            MapObject mapObject_people = new Human_class(createObjectName.Text, clickedPoint);
            mapObjects.Add(mapObject_people);
            Map.Markers.Add(mapObject_people.GetMarker());
        }

        public void createPointMarker(PointLatLng clickedPoint)
        {
            MapObject mapObject_point = new Location_class(createObjectName.Text, clickedPoint);
            mapObjects.Add(mapObject_point);
            Map.Markers.Add(mapObject_point.GetMarker());
        }

        public void createArea(List<PointLatLng> points) 
        {

            MapObject mapObject_area = new Area_class(createObjectName.Text, points);
            mapObjects.Add(mapObject_area);
            Map.Markers.Add(mapObject_area.GetMarker());

        }

        public void createPath(List<PointLatLng> points) 
        {
            MapObject mapObject_path = new Route_class(createObjectName.Text, points);
            mapObjects.Add(mapObject_path);
            Map.Markers.Add(mapObject_path.GetMarker());

        }

        private void MapLoaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Map_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        
        }

        private void radioButCreate_Checked(object sender, RoutedEventArgs e)
        {
            createmodecombo.IsEnabled = true;
            addbuttoncreate.IsEnabled = true;
            resetpointcreate.IsEnabled = true;
        }

        private void radioButSearch_Checked(object sender, RoutedEventArgs e)
        {
            createmodecombo.IsEnabled = false;
            addbuttoncreate.IsEnabled = false;
            resetpointcreate.IsEnabled = false;
        }

        private void addbuttoncreate_Click(object sender, RoutedEventArgs e)
        {

            switch (createmodecombo.SelectedIndex)
            {
                case 0:
                    {
                        createArea(areaspots);
                       
                        findsresult.Items.Add(mapObjects.Last().objectName + " - area");
                        
                        break;
                    }
                case 1:
                    {
                        createPointMarker(point);
                        findsresult.Items.Add(mapObjects.Last().objectName + " - point");
                        break;
                    }
                case 2:
                    {
                        createCarMarker(point);
                        findsresult.Items.Add(mapObjects.Last().objectName + " - car");
                        break;
                    }
                case 3:
                    {
                        createPeopleMarker(point);
                        findsresult.Items.Add(mapObjects.Last().objectName + " - people");
                        break;
                    }
                case 4:
                    {
                        createPath(pathspot);
                        
                        findsresult.Items.Add(mapObjects.Last().objectName + " - path");
                 
                        break;
                    }
            }
            areaspots = new List<PointLatLng>();
            pathspot = new List<PointLatLng>();
        }

        private void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
         //   Map.Position = mapObjects.Last().getFocus(); // не работает со списками
        }

        private void Map_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (getareagreatagain)
            {
                point = Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y);
                areaspots.Add(point);
                clickinfoY.Content = point.Lng;
                clickinfoX.Content = point.Lat;

            }
            else
            if (getpathgreatagain)
            {
                point = Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y);
                pathspot.Add(point);
                clickinfoY.Content = point.Lng;
                clickinfoX.Content = point.Lat;
            }
            else
            {
                point = Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y);
                clickinfoY.Content = point.Lng;
                clickinfoX.Content = point.Lat;
            }
        }

        private void createmodecombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (createmodecombo.SelectedIndex == 0) // area
            {
                getareagreatagain = true;
                getpathgreatagain = false;
            }

            if (createmodecombo.SelectedIndex == 1) // point
            {
                getareagreatagain = false;
                getpathgreatagain = false;
            }

            if (createmodecombo.SelectedIndex == 2) // car
            {
                getareagreatagain = false;
                getpathgreatagain = false;
            }

            if (createmodecombo.SelectedIndex == 3) // people
            {
                getareagreatagain = false;
                getpathgreatagain = false;
            }

            if (createmodecombo.SelectedIndex == 4) // path
            {
                getareagreatagain = false;
                getpathgreatagain = true;
            }

        }

        private void findsresult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Map.Position = mapObjects[findsresult.SelectedIndex].getFocus();
        }
    }
    
}




//public ref GMapMarker findRef()
//{
//    return ref new GMapMarker(new PointLatLng());
//}

//PointLatLng point = new PointLatLng(55.016511, 82.946152);

//GMapMarker marker = new GMapMarker(point)
//{
//    Shape = new Image
//    {
//        Width = 32, // ширина маркера
//        Height = 32, // высота маркера
//        ToolTip = "Honda CR-V", // всплывающая подсказка
//        Source = new BitmapImage(new Uri("pack://application:,,,/Resources/men.png")) // картинка
//    }
//};
//Map.Markers.Add(marker);

//GMapMarker marker = new GMapMarker(point)
//{
//    Shape = new Image
//    {
//        Width = 32, // ширина маркера
//        Height = 32, // высота маркера
//        ToolTip = "timetime", // всплывающая подсказка
//        Source = new BitmapImage(new Uri("pack://application:,,,/Resources/notMainSpot.png")) // картинка
//    }
//};





//if (Map.Markers.Count == 0)
//{
//    Map.Markers.Add(marker);
//    clickinfoX.Content = point.Lat;
//    clickinfoY.Content = point.Lng;

//}
//else
//{

//    Map.Markers.Add(marker);     // после выхода из метода ссылка обнуляется 
//    clickinfoX.Content = point.Lat;
//    clickinfoY.Content = point.Lng;
//}